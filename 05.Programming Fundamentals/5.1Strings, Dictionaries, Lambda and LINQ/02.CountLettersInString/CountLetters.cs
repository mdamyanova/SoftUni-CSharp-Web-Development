using System;

namespace _02.CountLettersInString
{
    using System.Collections.Generic;
    using System.Linq;

    public class CountLetters
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            input = input.ToLower();

            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences[input[i]] = 0;
                }
                    occurrences[input[i]] = occurrences[input[i]] + 1;
            }

            foreach (var path in occurrences.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{path.Key} -> {path.Value}");
            }

            Console.WriteLine();
        }
    }
}