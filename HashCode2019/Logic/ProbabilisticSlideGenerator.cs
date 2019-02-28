using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HashCode2019.Entities;

namespace HashCode2019.Logic
{
    public class ProbabilisticSlideGenerator : ISlideGenerator
    {

        static long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }

        static int weightedRand(Random r, int a) {
            var n = (long)a;
            var sum =  LongRandom(0, (n * (n + 1)) / 2, r);
            return (int)((Math.Sqrt(1 + 8 * sum) - 1) / 2);
        }

        

        static Slide generateSingleSlide(List<Photo> horizontal, List<Photo> vertical, bool remove)
        {
            // Choose random photo
            Random r = new Random();
            Orientation c;

            if (horizontal.Any() && vertical.Any())
            {
                c = r.Next(2) == 0 ? Orientation.Horizontal : Orientation.Vertical;
            } else if (horizontal.Any())
            {
                c = Orientation.Horizontal;
            } else if (vertical.Any())
            {
                c = Orientation.Vertical;
            } else
            {
                return null;
            }

            var s = new Slide();

            if (c == Orientation.Horizontal)
            {

                var horPhoto = weightedRand(r, horizontal.Count);
                var photo = horizontal[horPhoto];
                if (remove)
                {
                    horizontal.RemoveAt(horPhoto);
                }
                //photos.Remove(photo);
                s.Photos = new List<Photo> { photo };

            }
            else
            {
                var verPhoto = weightedRand(r, vertical.Count);
                var photo1 = vertical[verPhoto];
                if (remove)
                {
                    vertical.RemoveAt(verPhoto);
                }

                verPhoto = weightedRand(r, vertical.Count);
                var photo2 = vertical[verPhoto];
                if (remove)
                {
                    vertical.RemoveAt(verPhoto);
                }
                //photos.Remove(photo1);
                //photos.Remove(photo2);

                s.Photos = new List<Photo> { photo1, photo2 };
            }

            return s;
        }

        public List<Slide> generateSlide(List<Photo> photos)
        {
            var output = new List<Slide>();

            var horizontal = photos.Where(p => p.Orientation == Orientation.Horizontal).ToList();
            var vertical = photos.Where(p => p.Orientation == Orientation.Vertical).ToList();
            horizontal = horizontal.OrderBy(p => p.Tags.Count).ToList();
            vertical = vertical.OrderBy(p => p.Tags.Count).ToList();

            var slide1 = generateSingleSlide(horizontal, vertical, true);
            Slide slide2 = generateSingleSlide(horizontal, vertical, false);
            

            for (int i = 0; slide2 != null ; ++i, slide2 = generateSingleSlide(horizontal, vertical, false))
            {

                Slide bestSlide = null;
                var bestScore = 0;

                for (int s = 0; s < 1; ++s)
                {
                    var slide2Score = Score.ComputeScore(slide1, slide2);
                    if (slide2Score >= bestScore)
                    {
                        bestSlide = slide2;
                        bestScore = slide2Score;
                    }

                    slide2 = generateSingleSlide(horizontal, vertical, false);
                }

                // Pick best slide and remove duplicate photos
                if (bestSlide.Orientation == Orientation.Horizontal)
                {
                    horizontal.Remove(bestSlide.Photos.Single());
                } else
                {
                    vertical.Remove(bestSlide.Photos[0]);
                    vertical.Remove(bestSlide.Photos[1]);
                }

                // Add
                output.Add(bestSlide);
            }

            return output;
        }
    }
}
