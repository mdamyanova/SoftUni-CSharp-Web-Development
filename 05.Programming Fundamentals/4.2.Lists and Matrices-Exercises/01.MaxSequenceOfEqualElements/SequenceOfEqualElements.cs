using System;

namespace _01.MaxSequenceOfEqualElements
{
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceOfEqualElements
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxNumbers = 0;
            int count = 1;
            int maxCount = 1;
            int pos = 0;

            while (pos < nums.Count - 1)
            {
                if (nums[pos] == nums[pos + 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxNumbers = nums[pos];
                    }
                }
                else
                {
                    count = 1;
                }
                pos++;

                if (maxCount == 1)
                {
                    maxNumbers = nums[0];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumbers + " ");
            }

            Console.WriteLine();
        }
    }
}