using System;

namespace _07.MaxSequenceOfIncreasingElements
{
    using System.Linq;

    public class IncreasingElements
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;

            int bestStart = 0;
            int bestLen = 0;

            // int mostFrequent = numbers.GroupBy(value => value).
            //OrderByDescending(group => group.Count()).First().Key;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    len++;

                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestStart = start;
                    }
                }
                else
                {
                    start = i;
                    len = 1;
                }
            }

            for (int i = bestStart; i < bestLen + bestStart; i++)
            {
                Console.Write(nums[i] + " ");
            }

            Console.WriteLine();
        }
    }
}