using System;

namespace _01.RecursiveArraySum
{
    public class Startup
    {
        public static void Main()
        {
            int sum = FindSum(new int[] {1, 2, 3}, 0);
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