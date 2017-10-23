using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (num == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (num > 0)
                {                                       
                    stack.Push(num % 2);
                    num /= 2;
                }
                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }

                Console.WriteLine();
            }
        }
    }
}