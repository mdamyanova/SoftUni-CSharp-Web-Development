using System;

namespace _21.NumbersInReversedOrder
{
    public class NumbersInReversedOrder
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            ReversedOrder(input);
        }

        private static void ReversedOrder(string input)
        {
            string reversed = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }
            Console.WriteLine(reversed);
        }
    }
}