using System;

namespace _05.CompareCharArrays
{
    using System.Linq;

    public class CompareCharArrays
    {
        public static void Main()
        {
            char[] arr1 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            bool isFound = false;

            int length = Math.Min(arr1.Length, arr2.Length);

            for (int i = 0; i < length; i++)
            {                
                if (arr1[i] < arr2[i])
                {
                    Console.WriteLine(string.Join(string.Empty, arr1));
                    Console.WriteLine(string.Join(string.Empty, arr2));
                    isFound = true;
                    break;
                }
                if (arr1[i] > arr2[i])
                {
                    Console.WriteLine(string.Join(string.Empty, arr2));
                    Console.WriteLine(string.Join(string.Empty, arr1));
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                if (length == arr1.Length)
                {
                    Console.WriteLine(string.Join(string.Empty, arr1));
                    Console.WriteLine(string.Join(string.Empty, arr2));
                }
                else
                {
                    Console.WriteLine(string.Join(string.Empty, arr2));
                    Console.WriteLine(string.Join(string.Empty, arr1));
                }
            }           
        }
    }
}