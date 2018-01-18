namespace _04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            var numsOccurences = new Dictionary<int, int>();

            for (int i = 0; i < nums.Count; i++)
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
                if (pair.Value % 2 == 1)
                {
                    nums.RemoveAll(n => n == pair.Key);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}