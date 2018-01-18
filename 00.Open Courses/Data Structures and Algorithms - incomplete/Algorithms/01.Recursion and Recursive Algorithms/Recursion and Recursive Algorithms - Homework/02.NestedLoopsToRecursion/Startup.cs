using System;

namespace _02.NestedLoopsToRecursion
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GetIteration(arr, 0);
        }

        private static void GetIteration(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                // combination is found
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[index] = i;
                    GetIteration(arr, index + 1);
                }
            }
        }
    }
}
