using System;

namespace _06.CountStringOccurrences
{
    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();

            var counter = 0;
            var index =  text.IndexOf(word);

            while (index != -1)
            {               
                index = text.IndexOf(word, index + 1);
                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}