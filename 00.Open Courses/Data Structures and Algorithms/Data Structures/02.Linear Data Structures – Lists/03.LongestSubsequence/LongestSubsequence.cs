namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var longestSubsequence = FindLongestSubsequence(input);

            Console.WriteLine(string.Join(" ", longestSubsequence));
        }

        public static List<int> FindLongestSubsequence(List<int> input)
        {
            var longestSequence = int.MinValue;
            var startIndex = int.MinValue;

            for (int i = 0; i < input.Count; i++)
            {
                var currNum = input[i];
                var currCount = 1;

                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[j] != currNum)
                    {
                        break;
                    }
                    currCount++;
                }

                if (currCount > longestSequence)
                {
                    longestSequence = currCount;
                    startIndex = i;
                }
            }

            var result = new List<int>(input.Skip(startIndex).Take(longestSequence));

            return result;
        }
    }
}