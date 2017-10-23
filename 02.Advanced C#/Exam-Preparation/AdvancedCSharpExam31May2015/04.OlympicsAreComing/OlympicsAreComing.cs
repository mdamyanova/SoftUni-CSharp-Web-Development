//You’ll receive information about the winners of some sports events in format: "[athlete] | [country]". 
//Your employer needs the data fast, so at some point he’ll tell you to stop and "report". 
//Your task is to aggregate the data and print it on the console. The data for each country should be on 
//a separate line and should be in format: "[country] ([numberOfParticipants] participants): [wins] wins". 
//The number of participants reflects the number of unique athletes as some of them may have won more than 
//one contest (name comparison should be case-sensitive). The countries should be ordered by the number of
//wins in descending order, meaning that you should print first the country with the most total wins. In case 
//several countries have the same number of wins, print them in the order in which they have been added to the database.
//Make sure to remove all unnecessary whitespaces from the names of the countries and the athletes; if a name consists 
//of two words they should be separated by a single space and there shouldn’t be any leading or trailing whitespaces.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class OlympicsAreComing
{
    static void Main()
    {
        var dictionary = new Dictionary<string, List<string>>();

        string input = Console.ReadLine();

        while (input != "report")
        {
            string[] athleteAndCountry = input.Split('|');
            string athlete = athleteAndCountry[0];
            string country = athleteAndCountry[1];
            athlete = Regex.Replace(athlete, @"\s+", " ").Trim();
            country = Regex.Replace(country, @"\s+", " ").Trim();

            if (!dictionary.ContainsKey(country))
            {
                dictionary.Add(country, new List<string>());
            }

            dictionary[country].Add(athlete);
            input = Console.ReadLine();
        }

       var orderedDictionary =
            dictionary.OrderByDescending(x => x.Value.Count);

        foreach (var keyValuePair in orderedDictionary)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",
                keyValuePair.Key,
                keyValuePair.Value.Distinct().Count(),
                keyValuePair.Value.Count);
        }
    }
}

