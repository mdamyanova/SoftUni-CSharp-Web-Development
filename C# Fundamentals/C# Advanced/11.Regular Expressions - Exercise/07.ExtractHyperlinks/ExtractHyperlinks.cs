using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _07.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var line = String.Empty;
            var sb = new StringBuilder();

            while ((line = Console.ReadLine()) != "END")
            {
                sb.AppendLine(line);
            }

            var regex = new Regex("<a\\s+([^>]+\\s+)?href\\s*=\\s*('([^']*)'|\"([^\"]*)|([^\\s>]+))[^>]*>");
            var matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                var hrefValue = match.Groups[3].Value;

                if (string.IsNullOrEmpty(hrefValue))
                {
                    hrefValue = match.Groups[4].Value;
                }

                if (string.IsNullOrEmpty(hrefValue))
                {
                    hrefValue = match.Groups[5].Value;
                }

                Console.WriteLine(hrefValue);
            }
        }
    }
}