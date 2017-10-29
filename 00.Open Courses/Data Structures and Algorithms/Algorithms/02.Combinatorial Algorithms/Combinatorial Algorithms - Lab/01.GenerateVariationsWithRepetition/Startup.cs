using System;

namespace _01.GenerateVariationsWithRepetition
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            GenerateVariations(array, n);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateVariations(array, sizeOfSet, index + 1);
                }
            }           
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}