using System;

namespace _04.OccurrencesInString
{
    public class OccurrencesInString
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string substr = Console.ReadLine().ToLower();

            int startPos = 0;
            int count = 0;
            while (true)
            {
                int pos = text.IndexOf(substr, startPos);
                if (pos == -1)
                {
                    // Occurrence not found
                    break;
                }

                // Found occurence
                count++;
                startPos = pos + 1;
            }

            Console.WriteLine(count);
        }
    }
}