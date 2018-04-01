namespace _01.RecursiveArraySum
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse);
            var sum = FindSum(nums, 0);
            Console.WriteLine(sum);
        }

        public static int FindSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + FindSum(arr, index + 1);
        }
    }
}