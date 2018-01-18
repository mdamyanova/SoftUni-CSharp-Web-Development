namespace _05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numsOccurences = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var currNum = nums[i];

                if (!numsOccurences.ContainsKey(currNum))
                {
                    numsOccurences[currNum] = 1;
                }
                else
                {
                    numsOccurences[currNum] = numsOccurences[currNum] + 1;
                }
            }

            foreach (var pair in numsOccurences)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }
        }
    }
}