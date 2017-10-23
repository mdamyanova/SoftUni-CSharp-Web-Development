//Write a program that reads a keyword and some text from the 
//console and prints all sentences from the text, containing that word.
//A sentence is any sequence of words ending with '.', '!' or '?'. 

using System;
using System.Text.RegularExpressions;

class SentenceExtraxctor
{
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string pattern = @"\b[^.?!]+\b"+word+@"\b.*?[!.?]";
        Regex regex = new Regex(pattern);

        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}
