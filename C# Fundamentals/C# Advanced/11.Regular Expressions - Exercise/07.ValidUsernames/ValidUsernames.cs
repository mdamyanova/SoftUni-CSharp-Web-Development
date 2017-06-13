using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var usernames = input.Split();
            var validUsernames = new List<string>();

            var regex = new Regex("\\b[a-zA-Z][\\w_]{2,25}\\b");

            foreach (var username in usernames)
            {
                var matches = regex.Matches(username);

                foreach (Match match in matches)
                {
                    validUsernames.Add(match.Value);
                }
            }

            var maxLength = 0;
            var longestTwoWords = new string[2];

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                var currLength = validUsernames[i].Length + validUsernames[i + 1].Length;
                if (currLength > maxLength)
                {
                    maxLength = currLength;
                    longestTwoWords[0] = validUsernames[i];
                    longestTwoWords[1] = validUsernames[i + 1];
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, longestTwoWords));
        }
    }
}