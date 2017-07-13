using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var nations = new NationsBuilder();

        while (input != "Quit")
        {
            var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Bender":
                    var benderArgs = new List<string> {tokens[1], tokens[2], tokens[3], tokens[4]};
                    nations.AssignBender(benderArgs);
                    break;
                case "Monument":
                    var monumentArgs = new List<string> {tokens[1], tokens[2], tokens[3]};
                    nations.AssignMonument(monumentArgs);
                    break;
                case "War":
                    var nationWar = tokens[1];
                    nations.IssueWar(nationWar);
                    break;
                case "Status":
                    var nationStatus = tokens[1];
                    Console.WriteLine(nations.GetStatus(nationStatus));
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(nations.GetWarsRecord());
    }
}