using System;

namespace _06.SquareNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class SquareNumbers
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> squareNums = new List<int>();

            foreach (var number in numbers)
            {
                if (Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    squareNums.Add(number);
                }
            }

            squareNums.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", squareNums));

        }
    }
}
