using System;

namespace _02.ReverseAnArrayOfIntegers
{
    using System.Linq;

    public class ReverseArray
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                numbers[i] = currNum;
            }

            Console.WriteLine(string.Join(" ", numbers.Reverse()));
        }
    }
}