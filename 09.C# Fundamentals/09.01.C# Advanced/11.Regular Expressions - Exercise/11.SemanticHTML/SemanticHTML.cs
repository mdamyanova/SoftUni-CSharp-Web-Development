using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _11.SemanticHTML
{
    public class SemanticHTML
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var openTagPattern = "(\\s*)<(div).*((id|class)\\s*=\\s*\"(.*?)\").*(?=>)";
            var closeTagPattern = "(\\s*)<\\/div>\\s.*?(\\w+)\\s*-->";

            var result = new List<string>();

            while (input != "END")
            {
                string semanticHtml;
                if (input.Contains("<div"))
                {
                    var match = Regex.Match(input, openTagPattern);

                    semanticHtml = match.Value;
                    semanticHtml = semanticHtml.Replace(match.Groups[2].Value, match.Groups[5].Value);
                    semanticHtml = semanticHtml.Replace(match.Groups[3].Value, " ");
                    semanticHtml = Regex.Replace(semanticHtml.Trim(), "\\s+", " ");
                    semanticHtml = match.Groups[1].Value + semanticHtml + ">";
                    result.Add(semanticHtml);
                }
                else if (input.Contains("</div"))
                {
                    Match match = Regex.Match(input, closeTagPattern);
                    semanticHtml = match.Groups[1].Value +
                        "</" +
                        match.Groups[2].Value +
                        ">";
                    result.Add(semanticHtml);
                }
                else
                {
                    result.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}