using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class Program
    {
        public static void Main()
        {
            var peopleSortedByName = new SortedSet<Person>(new NameComparer());
            var peopleSortedByAge = new SortedSet<Person>(new AgeComparer());

            var peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, peopleSortedByName));
            Console.WriteLine(string.Join(Environment.NewLine, peopleSortedByAge));
        }
    }
}
