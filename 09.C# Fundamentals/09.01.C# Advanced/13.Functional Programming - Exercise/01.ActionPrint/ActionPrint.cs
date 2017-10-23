using System;
using System.Linq;

namespace _01.ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Action<string> printer =
                line =>
                    line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(Console.WriteLine);

            printer(input);

        }
    }
}