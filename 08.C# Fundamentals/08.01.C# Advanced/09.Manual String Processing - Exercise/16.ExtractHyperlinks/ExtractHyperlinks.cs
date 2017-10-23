using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _16.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var textBuilder = new StringBuilder();

            while (input != "END")
            {
                textBuilder.Append(input);
                input = Console.ReadLine();
            }

            var text = textBuilder.ToString();

            var pattern =
                @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                for (int i = 1; i <= match.Groups.Count - 1; i++)
                {
                    if (match.Groups[i].Length > 0)
                    {
                        Console.WriteLine(match.Groups[i]);
                    }
                }
            }
        }
    }
}