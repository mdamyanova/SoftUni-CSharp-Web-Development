namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var result = LongestSubsequence(input);

            Console.WriteLine(string.Join(" ", result));
        }

        private static IEnumerable<int> LongestSubsequence(List<int> nums)
        {
            var longestCount = int.MinValue;
            var startIndex = int.MinValue;

            for (int i = 0; i < nums.Count - 1; i++)
            {
                var currNum = nums[i];
                var currCount = 1;

                //iterate through next elements and compare them
                for (int j = i + 1; j < nums.Count; j++)
                {
                    var nextNum = nums[j];

                    if (nextNum != currNum)
                    {
                        break;
                    }

                    currCount++;
                }

                //check if we have found the longest subsequence
                if (currCount > longestCount)
                {
                    longestCount = currCount;
                    startIndex = i;
                }
            }

            var result = nums.Skip(startIndex).Take(longestCount).ToList();

            return result;
        }
    }
}