namespace _01.SumAndAverage
{
    using System;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            try
            {
                var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                Console.WriteLine("Sum={0}; Average={1}", list.Sum(), list.Average());
            }
            catch (FormatException)
            {
                Console.WriteLine("Input must be integer numbers on single line, separated by space");
            }
        }
    }
}