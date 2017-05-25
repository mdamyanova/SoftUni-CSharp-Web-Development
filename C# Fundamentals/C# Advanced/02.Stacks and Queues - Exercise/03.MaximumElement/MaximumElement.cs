using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                string op = input[0];

                switch (op)
                {
                    case "1":
                        stack.Push(int.Parse(input[1]));
                        break;
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        if (stack.Count != 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else
                        {
                            Console.WriteLine(0);
                        }
                        break;
                }
            }
        }
    }
}