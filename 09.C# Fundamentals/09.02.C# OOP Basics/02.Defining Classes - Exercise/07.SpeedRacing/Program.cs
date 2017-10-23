using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    public class Program
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var car = new Car(line[0], double.Parse(line[1]), double.Parse(line[2]));
                cars.Add(car);
            }

            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split();
                var model = tokens[1];
                var km = double.Parse(tokens[2]);
                var car = cars.FirstOrDefault(c => c.Model == model);
                car.DriveCar(km);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", cars));
        }
    }
}