using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var carModel = input[0];
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];
                var tyre1PS = double.Parse(input[5]);
                var tyre1Age = int.Parse(input[6]);
                var tyre2PS = double.Parse(input[7]);
                var tyre2Age = int.Parse(input[8]);
                var tyre3PS = double.Parse(input[9]);
                var tyre3Age = int.Parse(input[10]);
                var tyre4PS = double.Parse(input[11]);
                var tyre4Age = int.Parse(input[12]);

                var currentCar = new Car(carModel, engineSpeed, enginePower, cargoWeight, cargoType, tyre1PS, tyre1Age,
                    tyre2PS, tyre2Age, tyre3PS, tyre3Age, tyre4PS, tyre4Age);

                cars.Add(currentCar);
            }

            var command = Console.ReadLine();

            if (command.Equals("fragile"))
            {
                foreach (Car car in cars
                    .Where(c => c.Cargo.CargoType.Equals("fragile") &&
                    c.Tyres.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command.Equals("flamable"))
            {
                foreach (var car in cars
                    .Where(c => c.Cargo.CargoType.Equals("flamable") &&
                    c.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}