using System;
using System.Text.RegularExpressions;

namespace _03.ParseTags
{
    public class ParseTags
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", m => m.Groups[1].Value.ToUpper()));
        }
    }
}