using System;
using System.Linq;

namespace _04.AverageOfDoubles
{
    public class AverageOfDoubles
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            Console.WriteLine($"{numbers.Average():f2}");
        }
    }
}