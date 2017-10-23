using System;
using System.Linq;

namespace _06.FindAndSumIntegers
{
    public class FindAndSumIntegers
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.Split(' ')
                .Select(n =>
                {
                    long value;
                    bool success = long.TryParse(n, out value);
                    return new {value, success};
                })
                .Where(b => b.success)
                .Select(x => x.value)
                .ToList();

            if (numbers.Any())
            {
                Console.WriteLine(numbers.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}