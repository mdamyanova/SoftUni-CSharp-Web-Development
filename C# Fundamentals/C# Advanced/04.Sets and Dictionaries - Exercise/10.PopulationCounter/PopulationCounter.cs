using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split('|');
            var statistic = new Dictionary<string, Dictionary<string, uint>>();
            while (input[0] != "report")
            {
                string country = input[1];
                string town = input[0];
                uint population = uint.Parse(input[2]);

                if (!statistic.ContainsKey(country))
                {
                    statistic.Add(country, new Dictionary<string, uint>());

                }

                statistic[country].Add(town, population);

                input = Console.ReadLine().Split('|');

            }
            var sortedPopulationData = statistic.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var pair in sortedPopulationData)
            {
                long totalPopulation = pair.Value.Sum(x => x.Value);
                Console.WriteLine("{0} (total population: {1})",
                    pair.Key,
                    totalPopulation);

                var orderedCityData = pair.Value.OrderByDescending(x => x.Value);

                foreach (var item in orderedCityData)
                {
                    Console.WriteLine("=>{0}: {1}", item.Key, item.Value);
                }
            }
        }
    }
}