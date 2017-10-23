using System;

namespace _06.MaxSequenceOfEqualElements
{
    using System.Linq;

    public class EqualElements
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;

            int bestStart = 0;
            int bestLen = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
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