using System;

namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + 0.9;
        }

        public override void Drive(double distance)
        {
            if (this.FuelQuantity >= distance * this.FuelConsumptionPerKm)
            {
                //can drive
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                //can't drive
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}