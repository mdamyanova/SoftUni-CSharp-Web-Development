using System;
using System.Text.RegularExpressions;

namespace _05.ExtractEmail
{
    public class ExtractEmail
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[0]);
            }
        }
    }
}