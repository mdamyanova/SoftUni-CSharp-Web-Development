using System;

namespace _11.SumReversedNumbers
{
    using System.Linq;

    public class SumReversedNumbers
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            long sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int num = input[i];
                int reverse = 0;
                while (num > 0)
                {
                    int rem = num % 10;
                    reverse = (reverse * 10) + rem;
                    num = num / 10;
                }

                sum += reverse;
            }

            Console.WriteLine(sum);
        }
    }
}