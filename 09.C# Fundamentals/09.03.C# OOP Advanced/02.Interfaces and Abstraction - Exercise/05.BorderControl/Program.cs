using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var citizensAndRobots = new List<IIdentifiable>();

            while (input != "End")
            {
                var tokens = input.Split();
                IIdentifiable citizenOrRobot;
                if (tokens.Length == 3)
                {
                    citizenOrRobot = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }
                else
                {
                    citizenOrRobot = new Robot(tokens[0], tokens[1]);
                }

                citizensAndRobots.Add(citizenOrRobot);
                input = Console.ReadLine();
            }

            var fakeId = Console.ReadLine();
            foreach (var x in citizensAndRobots.Where(x => x.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(x.Id);
            }
        }
    }
}