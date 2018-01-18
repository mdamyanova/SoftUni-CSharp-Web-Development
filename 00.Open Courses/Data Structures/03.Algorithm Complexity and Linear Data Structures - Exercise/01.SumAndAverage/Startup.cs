namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sum = 0;
            var average = 0d;

            if (!string.IsNullOrEmpty(input))
            {
                var nums = new List<int>();
                nums = input.Trim().Split().Select(int.Parse).ToList();

                sum = nums.Sum();
                average = nums.Average();
            }

            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}