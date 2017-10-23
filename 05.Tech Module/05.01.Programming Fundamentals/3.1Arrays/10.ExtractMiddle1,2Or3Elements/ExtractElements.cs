using System;

namespace _10.ExtractMiddle1_2Or3Elements
{
    using System.Linq;

    public class ExtractElements
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = numbers.Length;

            if (length == 1)
            {
                Console.WriteLine("{ " + numbers[0] + " }");
            }
            else if (length % 2 == 0)
            {
                Console.WriteLine("{ " + numbers[length / 2 - 1] + ", " + numbers[length / 2] + " }");
            }
            else
            {
                Console.WriteLine("{ " + numbers[length / 2 - 1] + ", " + numbers[length / 2] + ", " + numbers[length / 2 + 1] + " }");
            }
        }
    }
}