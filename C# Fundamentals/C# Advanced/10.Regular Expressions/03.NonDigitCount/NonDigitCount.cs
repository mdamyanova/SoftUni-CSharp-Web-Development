using System;
using System.Text.RegularExpressions;

namespace _03.NonDigitCount
{
    public class NonDigitCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex("[^0123456789]");
            var count = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}