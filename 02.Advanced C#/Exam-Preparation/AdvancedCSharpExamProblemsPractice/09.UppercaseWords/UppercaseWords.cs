//Write a program to reverse the letters of all uppercase words in a text.
//In case an uppercase word stays unchanged after reversing its letters, then 
//double each of its letters. A word is a sequence of Latin letters separated 
//by non-letter characters (e.g. punctuation characters or digits). For example,
//the text "PHP5 is the latest PHP currently, YES" consists of the following words: 
//PHP, is, the, latest, PHP, currently, YES.

using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        StringBuilder line = new StringBuilder();
        string pattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        Regex regex = new Regex(pattern);

        while (line.ToString() != "END")
        {          
            MatchCollection matches = regex.Matches(line.ToString());

            int offset = 0;
            foreach (Match match in matches)
            {
               string word = match.Value;
               string reversed = Reverse(word);
              
                if (reversed == word)
                {
                    reversed = DoubleEachLetter(reversed);
                }

                int index = match.Index;
                line = line.Remove(index + offset, word.Length);
                line = line.Insert(index + offset, reversed);
                offset += reversed.Length - word.Length;

            }

            Console.WriteLine(SecurityElement.Escape(line.ToString()));
            line = new StringBuilder(Console.ReadLine());
        }
    }

    private static string DoubleEachLetter(string reversed)
    {
        StringBuilder doubled = new StringBuilder();
        for (int i = 0; i < reversed.Length; i++)
        {
            doubled.Append(new string(reversed[i], 2));
        }

        return doubled.ToString();
    }

    private static string Reverse(string word)
    {
        StringBuilder reversed = new StringBuilder();

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed.Append(word[i]);
        }

        return reversed.ToString();
    }
}