using System;
using System.Text.RegularExpressions;

namespace _05.ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"<.*?>");

            while (line != "END")
            {
                var matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                line = Console.ReadLine();
            }
        }
    }
}