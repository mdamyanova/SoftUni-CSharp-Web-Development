//You are given an HTML code, written in the old non-semantic style using tags like <div id="header">, 
//<div class="section">, etc. Your task is to write a program that converts this HTML to semantic HTML by 
//changing tags like <div id="header"> to their semantic equivalent like <header>.
//The non-semantic tags that should be converted are always<div>s and have either id or class with 
//one of the following values: "main", "header", "nav", "article", "section", "aside" or "footer". 
//Their corresponding closing tags are always followed by a comment like<!-- header -->, <!-- nav -->,
//etc.staying at the same line, after the tag.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        string input = Console.ReadLine();
        string openTagPattern = "(\\s*)<(div).*((id|class)\\s*=\\s*\"(.*?)\").*(?=>)";
        string closeTagPattern = "(\\s*)<\\/div>\\s.*?(\\w+)\\s*-->";
        string semanticHtml;
        List<string> result = new List<string>();

        while (input != "END")
        {
            if (input.Contains("<div"))
            {
                Match match = Regex.Match(input, openTagPattern);

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