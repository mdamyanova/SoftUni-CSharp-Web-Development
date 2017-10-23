//Write a program to extract all hyperlinks(<href=…>) from a given text. The text comes 
//from the console on a variable number of lines and ends with the command "END". Print at 
//the console the href values in the text. The input text is standard HTML code.It may hold 
//many tags and can be formatted in many different forms (with or without whitespace). The<a> 
//elements may have many attributes, not only href.You should extract only the values of the 
//href attributes of all<a> elements.

using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder textBuilder = new StringBuilder();

        while (input != "END")
        {
            textBuilder.Append(input);
            input = Console.ReadLine();
        }
        string text = textBuilder.ToString();

        string pattern =
            @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

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