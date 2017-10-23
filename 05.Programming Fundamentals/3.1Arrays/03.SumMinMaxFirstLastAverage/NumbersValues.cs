using System;

namespace _03.SumMinMaxFirstLastAverage
{
    using System.Linq;

    public class NumbersValues
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                numbers[i] = currNum;
            }

            Console.WriteLine($"Sum = {numbers.Sum()}\n" +
                $"Min = {numbers.Min()}\nMax = {numbers.Max()}\n" +
                $"First = {numbers.First()}\nLast = {numbers.Last()}\nAverage = {numbers.Average()}");
        }
    }
}