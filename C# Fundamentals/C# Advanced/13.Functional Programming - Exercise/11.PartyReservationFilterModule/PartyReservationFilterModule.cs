using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    public static class PartyReservationFilterModule
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filters = new List<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Print")
                {
                    break;
                }

                var tokens = command
                    .Split(new char[] { }, 2, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var actions = tokens[0];
                var subFilter = tokens[1];

                if (actions == "Add")
                {
                    filters.Add(subFilter);
                }
                else if (actions == "Remove")
                {
                    filters.Remove(subFilter);
                }
            }

            foreach (var filter in filters)
            {
                var tokens = filter
                    .Split(new char[] { ';' })
                    .ToArray();

                var condition = tokens[1].Trim();
                var param = tokens[2].Trim();

                if (condition == "Starts with")
                {
                    names.RemoveAll(x => x.StartsWith(param));
                }
                else if (condition == "Ends with")
                {
                    names.RemoveAll(x => x.EndsWith(param));
                }
                else if (condition == "Length")
                {
                    names.RemoveAll(x => x.Length == int.Parse(param));
                }
                else if (condition == "Contains")
                {
                    names.RemoveAll(x => x.Contains(param));
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}