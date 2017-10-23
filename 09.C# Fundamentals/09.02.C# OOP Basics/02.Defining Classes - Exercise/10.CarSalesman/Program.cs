using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    public class Program
    {
        public static void Main()
        {
            var enginesCount = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                var engineInfo = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var engine = new Engine(model, power);

                if (engineInfo.Length > 2)
                {
                    if (engineInfo.Length == 3)
                    {
                        int displacement;
                        var displValue = int.TryParse(engineInfo[2], out displacement);

                        if (displValue)
                        {
                            engine.Displacement = displacement;
                        }

                        else
                        {
                            engine.Efficienty = engineInfo[2];
                        }
                    }

                    else
                    {
                        var displacement = int.Parse(engineInfo[2]);
                        var efficienty = engineInfo.Last();

                        engine.Displacement = displacement;
                        engine.Efficienty = efficienty;
                    }
                }

                engines.Add(engine);
            }

            var carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                var carInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo.First();
                var engineType = carInfo[1];
                var engine = engines.FirstOrDefault(e => e.Model == engineType);

                var car = new Car(model, engine);

                if (carInfo.Length > 2)
                {
                    if (carInfo.Length == 3)
                    {
                        int weight;
                        var weightValue = int.TryParse(carInfo[2], out weight);

                        if (weightValue)
                        {
                            car.Weight = weight;
                        }

                        else
                        {
                            car.Color = carInfo[2];
                        }
                    }

                    else
                    {
                        car.Weight = int.Parse(carInfo[2]);
                        car.Color = carInfo[3];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement != 0)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                Console.WriteLine($"    Efficiency: {car.Engine.Efficienty}");

                if (car.Weight != 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}