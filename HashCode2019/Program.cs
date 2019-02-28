using HashCode2019.Entities;
using HashCode2019.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using HashCode2019.Inputs;
using HashCode2019.Logic;

namespace HashCode2019
{
    class Program
    {
        public static InputReading curStructure = new InputReading();

        static void Main(string[] args)
        {
            // C:\Users\kvnna\Source\Repos\Hash-Code-2019\HashCode2019\c_memorable_moments.txt
            string allFile = FileReader.ReadFile(@"C:\Users\kvnna\Source\Repos\Hash-Code-2019\HashCode2019\Inputs\d_pet_pictures.txt");
            var firstLine = FileReader.GetFirstLine(allFile);
            List<string> otherLines = FileReader.GetOtherLines(allFile);
            curStructure = Parser.ParseAll(firstLine, otherLines);

            ISlideGenerator generator = new ProbabilisticSlideGenerator();

            var slideshow = generator.generateSlide(curStructure.Photos);

            var score = Score.ComputeScore(slideshow);

            PrintOutput(slideshow);
            Console.ReadKey();
        }

        public static void PrintOutput(List<Slide> slideshows)
        {
            using (StreamWriter outputFile = new StreamWriter("Output.txt"))
            {
                outputFile.WriteLine(slideshows.Count);

                foreach (var slide in slideshows)
                    outputFile.WriteLine(string.Join(' ', slide.Photos.Select(x => x.PhotoID)));
            }

        }
    }
}
