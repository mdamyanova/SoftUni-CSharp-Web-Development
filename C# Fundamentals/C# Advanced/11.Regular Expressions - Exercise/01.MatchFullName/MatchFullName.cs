using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b");

            while (line != "end")
            {
                var match = regex.Match(line);

                if (match.Success)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }

                line = Console.ReadLine();
            }
        }
    }
}