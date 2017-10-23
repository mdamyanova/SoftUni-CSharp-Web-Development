using System;

namespace _06.CountRealNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class CountRealNumbers
    {
        public static void Main()
        {
            decimal[] nums = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            SortedDictionary<decimal, int> occurences = new SortedDictionary<decimal, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!occurences.ContainsKey(nums[i]))
                {
                    occurences[nums[i]] = 0;
                }

                occurences[nums[i]] = occurences[nums[i]] + 1;
            }

            foreach (var occurence in occurences)
            {
                Console.WriteLine($"{occurence.Key} -> {occurence.Value}");
            }
        }
    }
}