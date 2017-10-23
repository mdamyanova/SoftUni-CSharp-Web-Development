using System;

namespace _02.RotateAndSum
{
    using System.Linq;

    public class RotateAndSum
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int[] sum = new int[nums.Length];

            for (int currRotation = 0; currRotation < rotations; currRotation++)
            {
                int lastElement = nums[nums.Length - 1];

                Array.Copy(nums, 0, nums, 1, nums.Length - 1);

                nums[0] = lastElement;

                for (int currElement = 0; currElement < nums.Length; currElement++)
                {
                    sum[currElement] += nums[currElement];
                }
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}