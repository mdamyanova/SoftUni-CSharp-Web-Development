using System;

namespace _03.CensorYourEmailAddress
{
    using System.Linq;

    public class CensorEmailAddress
    {
        public static void Main()
        {
            string email = Console.ReadLine();
            string input = Console.ReadLine();

            string username = email.Substring(0, email.IndexOf('@'));
            string domain = email.Substring(email.IndexOf('@'));

            string replacement = new string('*', username.Length) + domain;
            input = input.Replace(email, replacement);

            Console.WriteLine(input);
        }
    }
}