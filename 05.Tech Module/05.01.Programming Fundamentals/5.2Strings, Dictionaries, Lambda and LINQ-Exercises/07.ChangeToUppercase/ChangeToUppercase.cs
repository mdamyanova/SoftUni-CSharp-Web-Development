using System;

namespace _07.ChangeToUppercase
{
    using System.Text.RegularExpressions;

    public class ChangeToUppercase
    {
        public static void Main()
        {
            string s = Console.ReadLine();
            string result = Regex.Replace(
                s,
                @"\<upcase\>(.*?)\</upcase\>",
                m =>
                    {
                        var replaced = m.Groups[1].Value;
                        return replaced.ToUpper();
                    });
            Console.WriteLine(result);
        }
    }
}