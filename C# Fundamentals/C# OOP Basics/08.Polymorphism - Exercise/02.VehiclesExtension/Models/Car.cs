using System;

namespace _02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLiterPerKm, tankCapacity)
        {
        }

        public override double GetAirConditionerConsumption()
        {
            return airConditionerConsumption;
        }
    }
}