using System;

namespace _03.ImplementAnArray_BasedStack
{
    public class StackDemo
    {
        public static void Main()
        {
            var stack = new ArrayStack<int>(2);

            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine(string.Join(", ", stack.ToArray())); //Prints the stack - 6, 5, 4, 3

            stack.Pop(); //Remove the last pushed - 6

            Console.WriteLine(string.Join(", ", stack.ToArray())); 


        }
    }
}