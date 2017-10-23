using System;

namespace _07.CountNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class CountNumbers
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (!count.ContainsKey(nums[i]))
                {
                    count.Add(nums[i], 1);
                }
                else
                {
                    count[nums[i]] = count[nums[i]] + 1;
                }
            }

            foreach (var item in count.OrderBy(i => i.Key))
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

            Console.WriteLine();
        }
    }
}