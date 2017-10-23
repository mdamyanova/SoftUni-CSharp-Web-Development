using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _10.UseYourChainsBuddy
{
    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"<p>(.[^\/]+)<\/p>";
            var regex = @"[^a-z0-9]+";

            var words = new Regex(pattern);
            var matches = words.Matches(text);
            var encrypted = "";

            for (int i = 0; i < matches.Count; i++)
            {
                var temp = matches[i].Groups[1].Value;
                encrypted += Regex.Replace(temp, regex, word => " ");
            }

            var manual = "";

            for (int i = 0; i < encrypted.Length; i++)
            {
                if (encrypted[i] >= 'a' && encrypted[i] <= 'm')
                {
                    manual += (char)(encrypted[i] + 13);
                }
                else if (encrypted[i] >= 'n' && encrypted[i] <= 'z')
                {
                    manual += (char)(encrypted[i] - 13);
                }
                else if (char.IsDigit(encrypted[i]) || char.IsWhiteSpace(encrypted[i]))
                {
                    manual += encrypted[i];
                }
            }

            Console.WriteLine(manual);
        }
    }
}