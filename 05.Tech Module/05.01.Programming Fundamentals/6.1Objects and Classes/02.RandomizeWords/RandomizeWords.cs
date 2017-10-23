using System;

namespace _02.RandomizeWords
{
    public class RandomizeWords
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split();
            Random rnd = new Random();

            for (int first = 0; first < words.Length; first++)
            {
                var second = rnd.Next(0, words.Length);
                var old = words[first];
                words[first] = words[second];
                words[second] = old;
            }

            Console.WriteLine(string.Join("\r\n", words));
        }
    }
}