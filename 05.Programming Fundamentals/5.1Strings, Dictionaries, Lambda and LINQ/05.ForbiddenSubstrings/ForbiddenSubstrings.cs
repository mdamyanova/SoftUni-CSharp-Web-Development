using System;

namespace _05.ForbiddenSubstrings
{
    public class ForbiddenSubstrings
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string[] words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                string stars = new string('*', word.Length);
                text = text.Replace(word, stars);
            }

            Console.WriteLine(text);
        }
    }
}