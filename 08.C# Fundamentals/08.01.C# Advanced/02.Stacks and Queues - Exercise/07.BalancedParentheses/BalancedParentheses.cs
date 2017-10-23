using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParentheses
{
    public class BalancedParentheses
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var isBalanced = true;

            foreach (char ch in input)
            {
                switch (ch)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(ch);
                        break;

                    case '}':
                        if (!stack.Any())
                        {
                            isBalanced = false;
                        }
                        else if (stack.Pop() != '{')
                        {
                            isBalanced = false;
                        }
                        break;
                    case ')':
                        if (!stack.Any())
                        {
                            isBalanced = false;
                        }
                        else if (stack.Pop() != '(')
                        {
                            isBalanced = false;
                        }
                        break;
                    case ']':
                        if (!stack.Any())
                        {
                            isBalanced = false;
                        }
                        else if (stack.Pop() != '[')
                        {
                            isBalanced = false;
                        }
                        break;
                }
                if (!isBalanced)
                {
                    break;
                }
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}