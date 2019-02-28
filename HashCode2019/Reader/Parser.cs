using HashCode2019.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2019.Reader
{
    public static class Parser
    {
        public static Structure ParseAll(string firstLine, List<string> otherLines)
        {
            Structure structure = new Structure();
            List<int> seps = firstLine.Split(' ').Select(x => Int32.Parse(x)).ToList();

            //structure.MinIngredients = seps[2];
            //structure.MaxIngredients = seps[3];

            var numRows = structure.Rows = seps[0];
            var numColumns = structure.Columns = seps[1];

            //structure.Sections = new List<List<PizzaSection>>(numRows);

            //for (int i = 0; i < numRows; i++)
            //{
            //    structure.Sections.Add(ParseLine(i, otherLines[i], numColumns));
            //}

            return structure;
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
