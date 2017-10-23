using System;

namespace _02.ArrayModifier
{
    using System.Linq;

    public class ArrayModifier
    {
        public static void Main()
        {
            long[] nums = Console.ReadLine().Split().Select(long.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] args = command.Split();

                switch (args[0])
                {
                    case "swap":
                        SwapElements(nums, int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    case "multiply":
                        MultiplyElements(nums, int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    case "decrease":
                        DecreaseElements(nums);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", nums));
        }

        private static void SwapElements(long[] nums, int index1, int index2)
        {
            long oldValue = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = oldValue;
        }

        private static void MultiplyElements(long[] nums, int index1, int index2)
        {
            nums[index1] = nums[index1] * nums[index2];
        }

        private static void DecreaseElements(long[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i]--;
            }
        }
    }
}