using System;
using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"^[\w\d-]{3,16}$");

            while (line != "END")
            {
                var matches = regex.Matches(line);

                Console.WriteLine(matches.Count > 0 ? "valid" : "invalid");

                line = Console.ReadLine();
            }
        }
    }
}