using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.SrabskoUnleashed
{
    public class SrabskoUnleashed
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var venues = new Dictionary<string, Dictionary<string, int>>();

            while (input != "End")
            {
                var splitted = input.Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries);
                var name = splitted[0];

                if (name[name.Length - 1] != ' ')
                {
                    input = Console.ReadLine();
                    continue;
                }

                var venuePrices = splitted[1].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (venuePrices.Length < 3)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var ticketsCount = 0;
                var ticketsPrice = 0;

                try
                {
                    ticketsCount = int.Parse(venuePrices[venuePrices.Length - 1]);
                    ticketsPrice = int.Parse(venuePrices[venuePrices.Length - 2]);
                }
                catch (Exception)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var venue = "";

                for (int i = 0; i < venuePrices.Length - 2; i++)
                {
                    venue += venuePrices[i] + " ";
                }

                venue = venue.Trim();

                if (!venues.ContainsKey(venue))
                {
                    venues.Add(venue, new Dictionary<string, int>());
                }

                if (!venues[venue].ContainsKey(name))
                {
                    venues[venue].Add(name, 0);
                }

                int ticketSum = ticketsCount * ticketsPrice;

                venues[venue][name] += ticketSum;

                input = Console.ReadLine();
            }

            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);

                foreach (var v in venue.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {v.Key}-> {v.Value}");
                }
            }
        }
    }
}