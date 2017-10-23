using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    var tokens = input.Split(new []{" ", ", "}, StringSplitOptions.RemoveEmptyEntries);

                    switch (tokens[0])
                    {
                        case "Push":
                            var elements = tokens.Skip(1).ToList();
                            foreach (var element in elements)
                            {
                                stack.Push(element);
                            }
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                input = Console.ReadLine();
            }

            foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}