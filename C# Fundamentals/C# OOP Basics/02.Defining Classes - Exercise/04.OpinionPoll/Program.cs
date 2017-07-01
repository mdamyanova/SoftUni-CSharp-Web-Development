using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());   
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                people.Add(new Person(input[0], int.Parse(input[1])));
            }

            var over30ordered = people.Where(p => p.Age > 30).OrderBy(p => p.Name);
            foreach (var person in over30ordered)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}