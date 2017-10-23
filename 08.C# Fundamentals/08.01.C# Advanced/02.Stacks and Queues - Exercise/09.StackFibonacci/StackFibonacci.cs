using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(1);
            

            for (int i = 2; i < n; i++)
            {
                long second = stack.Pop();
                long first = stack.Pop();
                long third = first + second;
                stack.Push(first);
                stack.Push(second);
                stack.Push(third);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
