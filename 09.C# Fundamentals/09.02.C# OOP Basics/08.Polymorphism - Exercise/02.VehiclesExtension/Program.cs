using System;
using System.Collections.Generic;
using System.Linq;
using _02.VehiclesExtension.Exceptions;
using _02.VehiclesExtension.Models;

namespace _02.VehiclesExtension
{
    public class Program
    {
        public static void Main()
        {
            var vehicles = new List<Vehicle>();
            ReadFromConsoleAndAddVehicles(vehicles);

            var numberOfInputCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputCommands; i++)
            {
                var inputCommandLine = Console.ReadLine().Split();

                var command = inputCommandLine[0];
                var vehicleType = inputCommandLine[1];
                double distanceOrLiters = double.Parse(inputCommandLine[2]);
                var vehicle = vehicles.FirstOrDefault(x => x.GetType().Name.ToString() == vehicleType);

                try
                {
                    if (command.Equals("Refuel", StringComparison.OrdinalIgnoreCase))
                    {
                        vehicle.Refuel(distanceOrLiters);
                    }
                    else
                    {
                        if (command.Equals("Drive", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicle.DriveWithAirConditioner(distanceOrLiters);
                        }
                        else if (command.Equals("DriveEmpty", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicle.DriveWithoutAirConditioner(distanceOrLiters);
                        }

                        Console.WriteLine($"{vehicleType} travelled {distanceOrLiters} km");
                    }
                }
                catch (InvalidVehicleException v)
                {
                    Console.WriteLine(v.Message);
                }
            }

            PrintRemainingFuelInEachVehicle(vehicles);
        }

        private static void ReadFromConsoleAndAddVehicles(List<Vehicle> vehicles)
        {
            try
            {
                var carInfo = Console.ReadLine().Split();
                vehicles.Add(new Car(double.Parse(carInfo[1]),
                    double.Parse(carInfo[2]),
                    double.Parse(carInfo[3])));

                var truckInfo = Console.ReadLine().Split();
                vehicles.Add(new Truck(double.Parse(truckInfo[1]),
                    double.Parse(truckInfo[2]),
                    double.Parse(truckInfo[3])));

                var busInfo = Console.ReadLine().Split();
                vehicles.Add(new Bus(double.Parse(busInfo[1]),
                    double.Parse(busInfo[2]),
                    double.Parse(busInfo[3])));
            }
            catch (InvalidVehicleException v)
            {
                Console.WriteLine(v.Message);
            }
        }

        private static void PrintRemainingFuelInEachVehicle(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.FuelQuantity:f2}");
            }
        }
    }
}