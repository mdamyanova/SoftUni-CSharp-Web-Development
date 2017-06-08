using System;
using System.Text.RegularExpressions;

namespace _04.ExtractIntegerNumbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex("\\d+");
            var result = regex.Matches(text);

            if (result.Count != 0)
            {
                foreach (Match match in result)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}