using System;

namespace _10.PairsByDifference
{
    using System.Linq;

    public class PairsByDifference
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (Math.Abs(numbers[i] - numbers[j]) == difference)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}