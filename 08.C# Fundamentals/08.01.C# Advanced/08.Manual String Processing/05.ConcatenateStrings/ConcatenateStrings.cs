using System;
using System.Text;

namespace _05.ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                sb.Append(input);
                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}