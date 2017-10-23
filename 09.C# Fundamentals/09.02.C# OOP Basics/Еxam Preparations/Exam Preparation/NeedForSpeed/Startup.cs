using System;
using NeedForSpeed.Commands;

namespace NeedForSpeed
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var manager = new CarManager();

            while (input != "Cops Are Here")
            {
                var tokens = input.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                switch (tokens[0])
                {
                    case "register":
                        var id = int.Parse(tokens[1]);
                        var typeCar = tokens[2];
                        var brand = tokens[3];
                        var model = tokens[4];
                        var year = int.Parse(tokens[5]);
                        var horsepower = int.Parse(tokens[6]);
                        var acceleration = int.Parse(tokens[7]);
                        var suspension = int.Parse(tokens[8]);
                        var durability = int.Parse(tokens[9]);
                        manager.Register(id, typeCar, brand, model, year, horsepower, acceleration, suspension, durability);
                        break;
                    case "check":
                        var checkId = int.Parse(tokens[1]);
                        Console.WriteLine(manager.Check(checkId));               
                        break;
                    case "open":
                        var openId = int.Parse(tokens[1]);
                        var type = tokens[2];
                        var length = int.Parse(tokens[3]);
                        var route = tokens[4];
                        var prizePool = int.Parse(tokens[5]);
                        manager.Open(openId, type, length, route, prizePool);
                        break;
                    case "participate":
                        var carIdParticipate = int.Parse(tokens[1]);
                        var raceIdParticipate = int.Parse(tokens[2]);
                        manager.Participate(carIdParticipate, raceIdParticipate);
                        break;
                    case "start":
                        var raceIdStart = int.Parse(tokens[1]);
                        Console.WriteLine(manager.Start(raceIdStart));
                        break;
                    case "park":
                        var carIdPark = int.Parse(tokens[1]);
                        manager.Park(carIdPark);
                        break;
                    case "unpark":
                        var carIdUnpark = int.Parse(tokens[1]);
                        manager.Unpark(carIdUnpark);
                        break;
                    case "tune":
                        var tuneIndex = int.Parse(tokens[1]);
                        var tuneAddOn = tokens[2];
                        manager.Tune(tuneIndex, tuneAddOn);
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}