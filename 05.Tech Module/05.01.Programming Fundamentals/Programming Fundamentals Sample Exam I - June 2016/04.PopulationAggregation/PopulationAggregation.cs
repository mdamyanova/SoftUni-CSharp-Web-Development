using System;

namespace _04.PopulationAggregation
{
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationAggregation
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var townsByCountry = new SortedDictionary<string, HashSet<string>>();
            var populationByTown = new Dictionary<string, decimal>();

            while (input != "stop")
            {
                string[] args = input.Split('\\');
                var population = decimal.Parse(args[2]);
                var country = RemoveChars(args[0]);
                var town = RemoveChars(args[1]);

                if (char.IsUpper(town[0]))
                {
                    var old = country;
                    country = town;
                    town = old;
                }

                // Add the current town to the current country
                if (townsByCountry.ContainsKey(country))
                {
                    townsByCountry[country].Add(town);
                }
                else
                {
                    townsByCountry[country] = new HashSet<string>() { town };
                }

                // Add the current population to the current town
                if (populationByTown.ContainsKey(town))
                {
                    populationByTown[town] = population;
                }
                else
                {
                    populationByTown[town] = population;
                }

                input = Console.ReadLine();
            }

            foreach (var countryAndTown in townsByCountry)
            {
                Console.WriteLine($"{countryAndTown.Key} -> {countryAndTown.Value.Distinct().Count()}");
            }

            var top3Population = populationByTown.OrderByDescending(p => p.Value).Take(3);

            foreach (var pair in top3Population)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static string RemoveChars(string str)
        {
            var validChars = str.Split("@#$&0123456789".ToArray());
            //var cleaned = Regex.Replace(str, "[0-9@#$&]+", "");
            var combined = string.Join("", validChars);

            return combined;
        }
    }
}