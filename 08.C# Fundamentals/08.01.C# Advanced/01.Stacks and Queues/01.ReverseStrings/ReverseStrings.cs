using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    public class ReverseStrings
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
