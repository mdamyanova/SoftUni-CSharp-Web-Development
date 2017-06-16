using System;
using System.Linq;

namespace _03.FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine()
            .Split(' ')
            .ToList();
            var letters = Console.ReadLine()
                .Split(' ')
                .Select(x => char.ToUpper(char.Parse(x)))
                .ToArray();
            var result = names
                .Where(name => Array.IndexOf(letters, Char.ToUpper(name[0])) >= 0)
                .OrderBy(x => x)
                .FirstOrDefault();

            Console.WriteLine(result == null ? "No match" : result);
        }
    }
}