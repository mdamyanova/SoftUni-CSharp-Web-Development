//Write a program that reads a list of words from the file words.txt and 
//finds how many times each of the words is contained in another file text.txt.
//Matching should be case-insensitive. Write the results in file results.txt.
//Sort the words by frequency in descending order. Use StreamReader in combination with StreamWriter.

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        StreamReader readerWords = new StreamReader(@"words.txt");
        StreamReader readerText = new StreamReader(@"text.txt");
        StreamWriter writer = new StreamWriter(@"results.txt");
        var results = new SortedDictionary<int, string>();

        using (readerWords)
        {
            using (readerText)
            {
                using (writer)
                {
                    string text = readerText.ReadToEnd().ToLower();
                    string word;

                    while ((word = readerWords.ReadLine()) != null)
                    {
                        string pattern = @"\b" + word.ToLower() + @"\b";
                        MatchCollection match = Regex.Matches(text, pattern);
                        results.Add(match.Count, word);
                    }

                    foreach (var item in results.Reverse())
                    {
                       writer.WriteLine("{0}-{1}", item.Value, item.Key);
                    }
                }
            }
        }
    }
}

