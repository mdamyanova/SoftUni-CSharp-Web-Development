using System;

namespace _04.SplitByWordCasting
{
    using System.Collections.Generic;

    public class SplitByWordCasting
    {
        public static void Main()
        {
            char[] separators = new[]
                                    {
                                        ',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '/', '[', ']', ' '
                                    };

            string[] input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> lowercase = new List<string>();
            List<string> uppercase = new List<string>();
            List<string> mixedcase = new List<string>();


            foreach (string word in input)
            {
                int lowerCount = 0;
                int upperCount = 0;

                foreach (char letter in word)
                {
                    if (char.IsUpper(letter))
                    {
                        upperCount++;
                    }
                    else if (char.IsLower(letter))
                    {
                        lowerCount++;
                    }
                }

                if (lowerCount == word.Length)
                {
                    lowercase.Add(word);
                }
                else if (upperCount == word.Length)
                {
                   uppercase.Add(word);
                }
                else
                {
                    mixedcase.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowercase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedcase));
            Console.WriteLine("Upper-case: " + string.Join(", ", uppercase));
        }
    }
}