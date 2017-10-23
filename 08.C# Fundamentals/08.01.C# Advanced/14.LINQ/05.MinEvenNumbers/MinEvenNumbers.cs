using System;
using System.Linq;

namespace _05.MinEvenNumbers
{
    public class MinEvenNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            var minEvenNumber = numbers.Where(n => n % 2 == 0);

            if (!minEvenNumber.Any())
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{minEvenNumber.Min():f2}");
            }           
        }
    }
}