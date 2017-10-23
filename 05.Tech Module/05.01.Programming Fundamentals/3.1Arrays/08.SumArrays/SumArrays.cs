using System;

namespace _08.SumArrays
{
    using System.Linq;

    public class SumArrays
    {
        public static void Main()
        {
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = Math.Max(firstArray.Length, secondArray.Length);

            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstArray[i % firstArray.Length] + secondArray[i % secondArray.Length];

            }

            Console.WriteLine(string.Join(" ", result));


        }
    }
}