using System;
using System.Text.RegularExpressions;

namespace _04.ReplaceATag
{
    public class ReplaceATag
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"<a.*?href=""(.*?)"">(.*?)<\/a>");

            while (line != "end")
            {
                var result = regex.Replace(line, @"[URL href=""$1""]$2[/URL]");
                Console.WriteLine(result);

                line = Console.ReadLine();
            }
        }
    }
}
