using System;

namespace _07.PredicateForNumbers
{
    public class PredicateForNumbers
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Predicate<string> filter = x => x.Length <= n;
            foreach (var name in names)
            {
                if (filter(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}