using System;

namespace _09.Capitalization
{
    public class Capitalization
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '.', ',', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in input)
            {
                var upper = char.ToUpper(word[0]);
                var left = word.Substring(1);
                Console.Write(upper + left + " ");
            }

            Console.WriteLine();
        }
    }
}