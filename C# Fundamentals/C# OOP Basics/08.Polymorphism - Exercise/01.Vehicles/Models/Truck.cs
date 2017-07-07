using System;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + 1.6;
        }

        public override void Drive(double distance)
        {
            if (this.FuelQuantity >= distance * this.FuelConsumptionPerKm)
            {
                //can drive
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                //can't drive
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
    }
}