using System;

namespace _05.SortNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class SortNumbers
    {
        public static void Main()
        {
            List<decimal> numbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            numbers.Sort();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                Console.Write(numbers[i] + " <= ");
            }

            Console.Write(numbers[numbers.Count - 1]);
            Console.WriteLine();
        }
    }
}