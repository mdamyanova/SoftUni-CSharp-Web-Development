using System;

namespace _09.IndexOfLetters
{
    public class IndexOfLetters
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            foreach (char letter in word)
            {
                Console.WriteLine($"{letter} -> {letter - 'a'}");
            }
        }
    }
}