using System;

namespace _08.Palindromes
{
    using System.Collections.Generic;
    using System.Linq;

    public class Palindromes
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> uniquePalindromes = new HashSet<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var reversed = new string(input[i].Reverse().ToArray());

                if (input[i] == reversed)
                {
                    uniquePalindromes.Add(input[i]);
                }
            }

            Console.WriteLine(string.Join(", ", uniquePalindromes.OrderBy(p => p)));

        }
    }
}