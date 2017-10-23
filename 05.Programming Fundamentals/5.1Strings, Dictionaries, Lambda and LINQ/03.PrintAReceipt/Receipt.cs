using System;

namespace _03.PrintAReceipt
{
    using System.Linq;

    public class Receipt
    {
        public static void Main()
        {
            decimal[] numbers = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            decimal total = 0;

            Console.WriteLine(@"/----------------------\");
            foreach (var num in numbers)
            {
                total += num;
                Console.WriteLine("| {0,20:f2} |", num);
            }

            Console.WriteLine("|----------------------|");
            Console.WriteLine($"| Total:{total,14:f2} |");
            Console.WriteLine(@"\----------------------/");
        }
    }
}