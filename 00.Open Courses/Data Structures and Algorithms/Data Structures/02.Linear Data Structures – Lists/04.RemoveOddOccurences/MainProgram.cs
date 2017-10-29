namespace _04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainProgram
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var nums = new List<int>(input.Distinct());
            foreach (var num in nums)
            {
                if (input.Count(n => n == num) % 2 == 1)
                {
                    input.RemoveAll(n => n == num);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}