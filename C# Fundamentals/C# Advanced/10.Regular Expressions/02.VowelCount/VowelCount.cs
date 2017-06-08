using System;
using System.Text.RegularExpressions;

namespace _02.VowelCount
{
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex("[AEIOUYaeiouy]");
            var count = regex.Matches(text).Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}