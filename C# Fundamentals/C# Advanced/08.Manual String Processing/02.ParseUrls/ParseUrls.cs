using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.ParseUrls
{
    public class ParseUrls
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var reminder = input.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (reminder.Length != 2  || !reminder[1].Contains('/'))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                var protocol = reminder[0];
                var serverEndIndex = reminder[1].IndexOf("/");
                var server = reminder[1].Substring(0, serverEndIndex);
                var resource = reminder[1].Substring(serverEndIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resource}");
            }
        }
    }
}