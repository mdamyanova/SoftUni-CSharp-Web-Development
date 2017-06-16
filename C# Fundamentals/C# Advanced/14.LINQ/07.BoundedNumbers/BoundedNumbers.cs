using System;
using System.Linq;

namespace _07.BoundedNumbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounders = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
            var left = bounders.Min();
            var right = bounders.Max();
            var resultNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x >= left && x <= right);
            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}