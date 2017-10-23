//The input comes from the console on a variable number of lines and ends when the keyword "END"
//is received.The input data will always be valid and in the format described.There is no need 
//to check it explicitly. Print at the console the information for each player (sorted by color name) 
//that holds the age, the name, a list with the opponents(in alphabetical order) and rank of the player.
//The rank of the players should be rounded to 2 digits after the decimal point.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class VladkosNotebook
{
    static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, Player> pagesByColor = 
            new Dictionary<string, Player>();
      
        while (line != "END")
        {
            string[] data = line.Split('|');
            string color = data[0];
            if (!pagesByColor.ContainsKey(color))
            {
                pagesByColor[color] = new Player();
                pagesByColor[color].Opponents = new List<string>();
            }

            Player currentPlayer = pagesByColor[color];
            if (data[1] == "age")
            {
                int age = int.Parse(data[2]);
                currentPlayer.Age = age;
            }
            else if (data[1] == "name")
            {
                currentPlayer.Name = data[2];
            }
            else if (data[1] == "win")
            {
               currentPlayer.WinCount++;
               currentPlayer.Opponents.Add(data[2]);
            }
            else if (data[1] == "loss")
            {
                currentPlayer.LossCount++;
                currentPlayer.Opponents.Add(data[2]);
            }

            line = Console.ReadLine();
        }

        var validPages = pagesByColor          
            .Where(p => p.Value.Age != 0 && p.Value.Name != null)
            .OrderBy(p => p.Key);

        if (validPages.Count() == 0)
        {
            Console.WriteLine("No data recovered.");
            return;
        }

        StringBuilder output = new StringBuilder();
        foreach (var page in validPages)
        {
            output.AppendLine(string.Format("Color: {0}", page.Key));
            output.AppendLine(string.Format("-age: {0}", page.Value.Age));
            output.AppendLine(string.Format("-name: {0}", page.Value.Name));

            string opponentsOutput = "(empty)";
            if (page.Value.Opponents.Count > 0)
            {
                var sortedOpponents = page.Value.Opponents.
                OrderBy(o => o, StringComparer.Ordinal);
                opponentsOutput = string.Join(", ", sortedOpponents);
            }
            
            output.AppendLine(string.Format("-opponents: {0}", 
               opponentsOutput));

            double rank = (page.Value.WinCount + 1) / (double)(page.Value.LossCount + 1);
            output.AppendLine(string.Format("-rank: {0:F2}", rank));
        }

        Console.WriteLine(output.ToString());
    }
}

class Player
{
    public string Name { get; set; }

    public int Age { get; set; }

    public List<string> Opponents { get; set; }

    public int WinCount { get; set; }

    public int LossCount { get; set; }
}

