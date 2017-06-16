using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Console.WriteLine(string.Join(", ", numbers.Where(n => n % 2 == 0).OrderBy(n => n)));
        }
    }
}