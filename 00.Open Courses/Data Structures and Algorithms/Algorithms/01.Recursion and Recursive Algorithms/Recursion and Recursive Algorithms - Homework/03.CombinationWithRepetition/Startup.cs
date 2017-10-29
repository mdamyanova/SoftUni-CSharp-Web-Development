using System;
using System.Collections.Generic;

namespace _03.CombinationWithRepetition
{
    public class Startup
    {
        private static HashSet<string> usedCombinations = new HashSet<string>();
        public static void Main()
        {    
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            GenerateCombinations(0, array, n);
        }

        private static void GenerateCombinations(int index, int[] arr, int n)
        {
            if (index == arr.Length)
            {
                int[] copiedArr = new int[arr.Length];
                Array.Copy(arr, copiedArr, arr.Length);
                Array.Sort(copiedArr);

                if (!usedCombinations.Contains(string.Join("", copiedArr)))
                {
                    usedCombinations.Add(string.Join("", copiedArr));
                    Console.WriteLine(string.Join(" ", arr));
                }

                return;     
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(index + 1, arr, n);
            }
        }
    }
}