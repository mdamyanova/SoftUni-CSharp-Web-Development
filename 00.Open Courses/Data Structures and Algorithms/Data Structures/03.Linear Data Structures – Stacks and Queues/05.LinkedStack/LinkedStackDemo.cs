using System;

namespace _05.LinkedStack
{
    public class LinkedStackDemo
    {
        public static void Main()
        {
            var stack = new LinkedStack<int>();

            stack.Push(4);
            stack.Push(3);

            Console.WriteLine(stack.Pop());

            var arr = stack.ToArray();
            Console.WriteLine(arr[0]);
        }
    }
}