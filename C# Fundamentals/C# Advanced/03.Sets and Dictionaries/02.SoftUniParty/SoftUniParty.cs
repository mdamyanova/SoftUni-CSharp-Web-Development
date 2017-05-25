using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var quests = new SortedSet<string>();
            var party = new SortedSet<string>();

            while (input != "PARTY")
            {
                quests.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                party.Add(input);
                input = Console.ReadLine();
            }

            var notGoing = new SortedSet<string>();

            foreach (var quest in quests)
            {
                if (!party.Contains(quest))
                {
                    notGoing.Add(quest);
                }
            }

            Console.WriteLine(notGoing.Count());
            Console.WriteLine(string.Join("\n", notGoing));
        }
    }
}