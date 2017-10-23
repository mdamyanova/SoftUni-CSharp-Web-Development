using System;


namespace _04.Substring
{
    public class Substring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            const char search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;

                    int endIndex = jump + 1;
                    string matchedString = "";

                    if (endIndex >= text.Length - i - 1)
                    {
                        matchedString = text.Substring(i);
                    }
                    else
                    {
                        matchedString = text.Substring(i, endIndex);
                    }

                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}