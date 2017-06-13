using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"\+359(\s|-)2\1([0-9]{3})\1([0-9]{4})\b");

            while (line != "end")
            {
                var match = regex.Match(line);

                if (match.Success)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }

                line = Console.ReadLine();
            }
        }
    }
}