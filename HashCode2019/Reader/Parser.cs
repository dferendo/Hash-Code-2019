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

            }

            return input;
        }

        public static void ParseLine(int curLine, string line, int numColumns)
        {
            //var result = new List<PizzaSection>(numColumns);
            //List<char> seps = line.ToCharArray().ToList();
            //for (int j = 0; j < numColumns; j++)
            //{
            //    switch (seps[j])
            //    {
            //        case 'T':
            //            result.Add(new PizzaSection(curLine, j, Ingredient.Tomato));
            //            break;
            //        case 'M':
            //            result.Add(new PizzaSection(curLine, j, Ingredient.Mushroom));
            //            break;
            //    }
            //}

            //return result;
        }

    }
}
