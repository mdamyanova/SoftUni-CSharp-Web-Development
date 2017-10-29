using System;

namespace _01.ReverseArray
{
    public class Startup
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split();
            ReverseArray(array, 0);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void ReverseArray(string[] arr, int index)
        {
            if (index >= arr.Length / 2)
            {
                return;
            }

            var temp = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;

            ReverseArray(arr, index + 1);

        }
    }
}