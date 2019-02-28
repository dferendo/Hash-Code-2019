using HashCode2019.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2019.Reader
{
    public static class Parser
    {
        public static InputReading ParseAll(string firstLine, List<string> otherLines)
        {
            var input = new InputReading();
            int numberOfPhotos = Int32.Parse(firstLine);
            input.Photos = new List<Photo>();

            input.NumberOfPhotos = numberOfPhotos;

            for (int i = 0; i < otherLines.Count; i++)
            {
                List<string> photoData = otherLines[i].Split(' ').ToList();

                string orientationString = photoData[0];
                int numberOfTags = Int32.Parse(photoData[1]);
                Orientation orientation;

                if (orientationString.Equals('H'))
                {
                    orientation = Orientation.Horizontal;
                } else
                {
                    orientation = Orientation.Vertical;
                }

                photoData.RemoveAt(0);
                photoData.RemoveAt(0);

                input.Photos.Add(new Photo()
                {
                    PhotoID = i,
                    Orientation = orientation,
                    Tags = photoData
                });
            }

            return input;
        }

    }
}
