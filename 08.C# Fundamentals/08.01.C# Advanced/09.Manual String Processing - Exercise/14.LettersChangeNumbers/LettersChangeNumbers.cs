using System;
using System.Linq;

namespace _14.LettersChangeNumbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            double result = 0;

            foreach (var item in input)
            {
                var firstLetter = item.First();
                var lastLetter = item.Last();
                var number = double.Parse(item.Substring(1, item.Length - 2));

                number = AddLeftCalculations(firstLetter, number);
                number = AddRightCalculations(lastLetter, number);

                result += number;
            }

            Console.WriteLine("{0:F2}", result);
        }

        private static double AddLeftCalculations(char str, double num)
        {
            if (char.IsUpper(str))
            {
                num /= str - 'A' + 1;
            }
            else if (char.IsLower(str))
            {
                num *= str - 'a' + 1;
            }

            return num;
        }

        public static double AddRightCalculations(char str, double num)
        {

            if (char.IsUpper(str))
            {
                num -= str - 'A' + 1;
            }
            else if (char.IsLower(str))
            {
                num += str - 'a' + 1;
            }

            return num;
        }
    }
}