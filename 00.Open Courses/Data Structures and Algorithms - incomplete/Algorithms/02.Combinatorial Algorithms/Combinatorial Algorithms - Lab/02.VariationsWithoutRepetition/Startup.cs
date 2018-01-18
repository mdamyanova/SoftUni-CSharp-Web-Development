using System;

namespace _02.VariationsWithoutRepetition
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            bool[] used = new bool[n + 1];
            GenerateVariations(array, n, used);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariations(array, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}