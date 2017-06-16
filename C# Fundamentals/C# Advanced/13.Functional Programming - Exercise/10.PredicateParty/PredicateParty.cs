using System;
using System.Linq;

namespace _10.PredicateParty
{
    public class PredicateParty
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split().ToList();
            var command = Console.ReadLine();

            while (command != "Party!")
            {
                var tokens = command.Split();

                if (tokens[0] == "Double")
                {
                    switch (tokens[1])
                    {
                        case "Length":
                            var num = int.Parse(tokens[2]);
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].Length == num)
                                {
                                    guests.Insert(i, guests[i]);
                                    i++;
                                }
                            }
                            break;
                        case "StartsWith":
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].StartsWith(tokens[2]))
                                {
                                    guests.Insert(i, guests[i]);
                                    i++;
                                }
                            }
                            break;
                        case "EndsWith":
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].EndsWith(tokens[2]))
                                {
                                    guests.Insert(i, guests[i]);
                                    i++;
                                }
                            }
                            break;
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    switch (tokens[1])
                    {
                        case "Length":
                            var num = int.Parse(tokens[2]);
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].Length == num)
                                {
                                    guests.RemoveAt(i);
                                    i--;
                                }
                            }
                            break;
                        case "StartsWith":
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].StartsWith(tokens[2]))
                                {
                                    guests.RemoveAt(i);
                                    i--;
                                }
                            }
                            break;
                        case "EndsWith":
                            for (int i = 0; i < guests.Count; i++)
                            {
                                if (guests[i].EndsWith(tokens[2]))
                                {
                                    guests.RemoveAt(i);
                                    i--;
                                }

                            }
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            if (guests.Any())
            {
                Console.WriteLine("{0} are going to the party!", string.Join(", ", guests));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }            
        }
    }
}