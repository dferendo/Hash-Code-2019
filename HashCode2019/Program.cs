using HashCode2019.Entities;
using HashCode2019.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashCode2019
{
    class Program
    {
        public const string Example = "c_memorable_moments.txt";
        public const string Small = "b_small.in";
        public const string Medium = "c_medium.in";
        public const string Big = "d_big.in";

        private static string currentFile = Example;

        public static InputReading curStructure = new InputReading();

        static void Main(string[] args)
        {
            string allFile = FileReader.ReadFile(@"C:\tree-personal\Hash-Code-2019\HashCode2019\c_memorable_moments.txt");

            var firstLine = FileReader.GetFirstLine(allFile);
            List<string> otherLines = FileReader.GetOtherLines(allFile);
            curStructure = Parser.ParseAll(firstLine, otherLines);

            //Code

            StringBuilder builder = new StringBuilder();

            //fill builder

            Console.WriteLine("\r");


            Console.WriteLine("X");
            Console.WriteLine("Y");
            Console.WriteLine("Finished calculation for " + currentFile);
            File.WriteAllText("result-" + currentFile + ".txt", builder.ToString());

            Console.ReadKey();
        }
    }
}
