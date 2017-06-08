using System;
using System.Text;

namespace _09.TextFilter
{
    public class TextFilter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                text = text.Replace(word, CreateAsterisk(word));
            }

            Console.WriteLine(text);
        }

        private static string CreateAsterisk(string str)
        {
            var result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                result.Append('*');
            }

            return result.ToString();
        }
    }
}