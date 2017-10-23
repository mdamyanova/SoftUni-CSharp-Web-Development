using System;

namespace _07.OddOccurrences
{
    using System.Collections.Generic;

    public class OddOccurences
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().ToLower().Split();
            
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            List<string> result = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences[input[i]] = 0;
                }

                occurrences[input[i]] = occurrences[input[i]] + 1;
            }

            foreach (var occurrence in occurrences)
            {
                if (occurrence.Value % 2 == 1)
                {
                    result.Add(occurrence.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}