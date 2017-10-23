using System;
using System.Text.RegularExpressions;

namespace _01.MatchCount
{
    public class MatchCount
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            var regex = new Regex(word);
            var count = regex.Matches(text).Count;

            Console.WriteLine(count);
        }
    }
}