using System;
using System.Text.RegularExpressions;

namespace _06.SentenceExtractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            var pattern = string.Format(@"[^.?!]+\b{0}\b.*?[!.?]", word);
            var regexKey = new Regex(pattern);
            var sentences = regexKey.Matches(text);

            foreach (Match sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}