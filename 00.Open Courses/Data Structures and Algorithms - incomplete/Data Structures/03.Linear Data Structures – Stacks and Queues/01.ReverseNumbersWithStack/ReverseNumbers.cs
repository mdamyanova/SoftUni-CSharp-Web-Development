namespace _01.ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            try
            {
                var input =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                var stack = new Stack<int>();
                foreach (var number in input)
                {
                    stack.Push(number);
                }

                while (stack.Count != 0)
                {
                    var number = stack.Pop();
                    Console.Write("{0} ", number);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
            }
        }
    }
}