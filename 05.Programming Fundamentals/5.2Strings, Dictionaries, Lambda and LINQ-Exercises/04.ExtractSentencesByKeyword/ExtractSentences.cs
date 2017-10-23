using System;

namespace _04.ExtractSentencesByKeyword
{
    public class ExtractSentences
    {
        public static void Main()
        {
            string keyword = Console.ReadLine();
            string[] sentences = Console.ReadLine().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in sentences)
            {
                string[] words = sentence.Split(new char[]
                                                    {
                                                        ',', ':', '(', ')', '[', ']', '\"', '\'', '/', '\\', ' '
                                                    }, 
                                                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (word == keyword)
                    {
                        Console.WriteLine(sentence.Trim());
                    }
                }
            }
        }
    }
}