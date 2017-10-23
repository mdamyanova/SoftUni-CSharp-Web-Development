using System;
using _01.Vehicles.Models;

namespace _01.Vehicles
{
    public class Program
    {
        public static void Main()
        {
            var carTokens = Console.ReadLine().Split();
            var truckTokens = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];
                var vehicle = input[1];
                var distanceOrLiters = double.Parse(input[2]);

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Drive(distanceOrLiters);
                    }
                    else
                    {
                        truck.Drive(distanceOrLiters);
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(distanceOrLiters);
                    }
                    else
                    {
                        truck.Refuel(distanceOrLiters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}