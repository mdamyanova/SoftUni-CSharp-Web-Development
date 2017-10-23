using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var elements = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();
            var reminder0 = new List<int>();
            var reminder1 = new List<int>();
            var reminder2 = new List<int>();

            foreach (var element in elements)
            {
                int reminder = element % 3;

                if (reminder == 0)
                {
                    reminder0.Add(element);
                }
                else if (reminder == 1 || reminder == -1)
                {
                    reminder1.Add(element);
                }
                else
                {
                    reminder2.Add(element);
                }
            }

            PrintList(reminder0);
            PrintList(reminder1);
            PrintList(reminder2);
        }

        private static void PrintList(List<int> numbers)
        {

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}