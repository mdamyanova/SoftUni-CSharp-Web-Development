using System;
using System.Linq;

namespace _01.ArrangeNumbers
{
    public class ArrangeIntegersMain
    {
        private static readonly string[] IntegerNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegerNames[ch - '0'])))));
        }
    }
}