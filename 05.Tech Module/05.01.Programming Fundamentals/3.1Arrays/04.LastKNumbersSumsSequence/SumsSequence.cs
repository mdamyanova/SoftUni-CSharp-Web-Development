using System;

namespace _04.LastKNumbersSumsSequence
{
    public class SumsSequence
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];

            numbers[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int prev = i - k; prev <= i - 1; prev++)
                {
                    if (prev >= 0)
                    {
                        sum += numbers[prev];
                    }
                }

                numbers[i] = sum;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}