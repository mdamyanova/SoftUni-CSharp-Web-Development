using System;

namespace _01.RemoveNegativesAndReverse
{
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveAndReverse
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> positiveNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    positiveNums.Add(numbers[i]);
                }
            }

            if (positiveNums.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                positiveNums.Reverse();
                foreach (var positiveNum in positiveNums)
                {
                    Console.Write(positiveNum + " ");
                }

                Console.WriteLine();
            }
        }
    }
}