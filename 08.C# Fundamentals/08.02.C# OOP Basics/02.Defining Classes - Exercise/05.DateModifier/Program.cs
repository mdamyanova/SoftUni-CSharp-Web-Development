using System;

namespace _05.DateModifier
{
    public class Program
    {
        public static void Main()
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();

            Console.WriteLine(DateModifier.FindDifferenceOfDays(first, second));
        }
    }
}
