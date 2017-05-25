using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var dictionary = new SortedDictionary<double, int>();

            foreach (var number in input)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 1);
                }
                else
                {
                    dictionary[number] += 1;
                }
            }

            foreach (var numbers in dictionary)
            {
                Console.WriteLine($"{numbers.Key} - {numbers.Value} times");
            }
        }
    }
}
