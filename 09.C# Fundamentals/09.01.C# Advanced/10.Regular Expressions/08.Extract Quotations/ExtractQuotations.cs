using System;
using System.Text.RegularExpressions;

namespace _08.Extract_Quotations
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex("(\"|')(.*?)\\1");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}