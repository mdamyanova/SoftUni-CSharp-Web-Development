using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.AshesOfRoses
{
    public class AshesOfRoses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"^Grow <(?<regionName>[A-Z][a-z]+)> <(?<colorName>[A-Za-z\d]+)> (?<roseAmount>\d+)$");

            var regions = new Dictionary<string, Dictionary<string, long>>();
            while (input != "Icarus, Ignite!")
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    var regionName = match.Groups["regionName"].Value;
                    var colorName = match.Groups["colorName"].Value;
                    var roseAmount = int.Parse(match.Groups["roseAmount"].Value);

                    if (regions.ContainsKey(regionName))
                    {
                        if (regions[regionName].ContainsKey(colorName))
                        {
                            regions[regionName][colorName] += roseAmount;
                        }
                        else
                        {
                            regions[regionName].Add(colorName, roseAmount);
                        }
                    }
                    else
                    {
                        var tempDic = new Dictionary<string, long> {{colorName, roseAmount}};
                        regions.Add(regionName, tempDic);
                    }
                }       
                
                input = Console.ReadLine();
            }

            //order by amount of roses in descending order
            //then in alphabetical order

            regions = regions
               .OrderByDescending(x => x.Value.Sum(y => y.Value))
               .ThenBy(x => x.Key)
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var region in regions)
            {
                Console.WriteLine(region.Key);

                //order by amount of roses in ascending
                //then by alphabetical order 

                var roses = region
                    .Value
                    .OrderBy(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var rose in roses)
                {
                    Console.WriteLine($"*--{rose.Key} | {rose.Value}");
                }
            }
        }
    }
}