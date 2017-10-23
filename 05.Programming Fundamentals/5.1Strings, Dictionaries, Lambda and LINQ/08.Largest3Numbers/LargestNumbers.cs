using System;

namespace _08.Largest3Numbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class LargestNumbers
    {
        public static void Main()
        {
            List<decimal> numbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            var result = numbers.OrderByDescending(x => x).Take(3);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}