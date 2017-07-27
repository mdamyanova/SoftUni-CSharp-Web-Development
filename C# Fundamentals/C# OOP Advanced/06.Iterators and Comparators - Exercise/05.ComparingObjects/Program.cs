using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            var equalPeopleCount = 0;
            var nonequalPeopleCount = 0;
            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            var indexOfPerson = int.Parse(Console.ReadLine()) - 1;
            var personToCompare = people[indexOfPerson];

            foreach (var person in people)
            {
                var value = person.CompareTo(personToCompare);

                if (value == 0)
                {
                    equalPeopleCount++;
                }
                else
                {
                    nonequalPeopleCount++;
                }
            }

            Console.WriteLine(equalPeopleCount == 1
                ? "No matches"
                : $"{equalPeopleCount} {nonequalPeopleCount} {people.Count}");
        }
    }
}