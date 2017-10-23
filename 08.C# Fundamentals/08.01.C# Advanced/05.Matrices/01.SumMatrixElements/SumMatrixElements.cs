using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.SumMatrixElements
{
    public class SumMatrixElements
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var dimensions = Regex.Split(input, ", ").Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var counter = 0;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                var elements = Regex.Split(line, ", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    counter += elements[col];
                }
            }

            Console.WriteLine($"{rows}\n{cols}\n{counter}");
        }
    }
}