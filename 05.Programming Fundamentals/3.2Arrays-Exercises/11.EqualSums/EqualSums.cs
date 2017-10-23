using System;

namespace _11.EqualSums
{
    using System.Linq;

    public class EqualSums
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isIndexFound = false;

            for (int i = 0; i < nums.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sumRight += nums[j];
                }
                for (int j = 0; j < i; j++)
                {
                    sumLeft += nums[j];
                }

                if (sumRight == sumLeft)
                {
                    Console.WriteLine(i);
                    isIndexFound = true;
                    break;
                }
            }

            if (!isIndexFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}