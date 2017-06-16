using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            words.Where(checker).ToList().ForEach(Console.WriteLine);
        }
    }
}