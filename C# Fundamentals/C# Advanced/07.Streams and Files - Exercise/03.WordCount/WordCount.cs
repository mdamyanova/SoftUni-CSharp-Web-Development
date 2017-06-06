using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            var readerWords = new StreamReader("../../words.txt");
            var readerText = new StreamReader("../../text.txt");
            var writer = new StreamWriter("../../results.txt");
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
}