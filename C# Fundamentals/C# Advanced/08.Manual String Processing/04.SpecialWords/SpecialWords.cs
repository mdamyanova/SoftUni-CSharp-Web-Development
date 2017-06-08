using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SpecialWords
{
    public class SpecialWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();
            var text = Console.ReadLine()
                .Split(new char[] {'(', ')', '[', ']', '<', '>', '-', '!', '?', ' '}, StringSplitOptions.RemoveEmptyEntries);

            var specialWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                specialWords[words[i]] = 0;

            }

            for (int i = 0; i < text.Length; i++)
            {
                var currentWord = text[i];

                if (specialWords.ContainsKey(currentWord))
                {
                    specialWords[currentWord]++;
                }

            }

            foreach (var w in specialWords)
            {
                Console.WriteLine($"{w.Key} - {w.Value}");
            }
        }
    }
}