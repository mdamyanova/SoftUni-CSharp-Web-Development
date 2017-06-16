using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = n => n % divisor != 0;
            var remainingNumbers = numbers.Reverse().Where(filter);

            Console.WriteLine(string.Join(" ", remainingNumbers));
        }
    }
}