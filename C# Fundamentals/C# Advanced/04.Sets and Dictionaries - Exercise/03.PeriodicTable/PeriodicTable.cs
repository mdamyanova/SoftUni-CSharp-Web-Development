using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sortedSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                foreach(var item in input)
                {
                    sortedSet.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", sortedSet));
        }
    }
}