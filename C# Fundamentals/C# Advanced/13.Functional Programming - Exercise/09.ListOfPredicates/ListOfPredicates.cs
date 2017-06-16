using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var output = new List<int>();
            Func<int[], int, bool> checker = Predicates;

            for (int i = 1; i <= range; i++)
            {
                if (checker(numbers, i))
                {
                    output.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }

        public static bool Predicates(int[] nums, int n)
        {
            var counter = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (n % nums[i] == 0)
                {
                    counter++;
                }
            }

            if (counter == nums.Length)
            {
                return true;
            }

            return false;
        }
    }
}