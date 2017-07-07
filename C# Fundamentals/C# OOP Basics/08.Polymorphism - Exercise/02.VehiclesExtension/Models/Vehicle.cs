using System;
using _02.VehiclesExtension.Exceptions;

namespace _02.VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionLiterPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLiterPerKm = fuelConsumptionLiterPerKm;
            this.TankCapacity = tankCapacity;
        }

        public Vehicle(double fuelQuantity, double fuelConsumptionLiterPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumptionLiterPerKm = fuelConsumptionLiterPerKm;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumptionLiterPerKm
        {
            get { return this.fuelConsumptionLiterPerKm; }
            set { this.fuelConsumptionLiterPerKm = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidTankCapacityException();
                }

                this.tankCapacity = value;
            }
        }

        public abstract double GetAirConditionerConsumption();

        private void Drive(double distance, double consumptionPerLiter)
        {
            var fuelConsumption = distance * consumptionPerLiter;

            if (this.FuelQuantity > 
                fuelConsumption)
            {
                this.FuelQuantity -= fuelConsumption;
            }
            else
            {
                throw new InvalidDriveException($"{this.GetType().Name} needs refueling");
            }
        }

        public void DriveWithAirConditioner(double distance)
        {
            double airConditionerConsumption = GetAirConditionerConsumption();
            var consumptionPerLiter = (this.FuelConsumptionLiterPerKm + airConditionerConsumption);

            Drive(distance, consumptionPerLiter);
        }

        public void DriveWithoutAirConditioner(double distance)
        {
            Drive(distance, this.FuelConsumptionLiterPerKm);
        }

        public virtual void Refuel(double liters)
        {
            if (liters >= 0 &&
                (this.FuelQuantity + liters) <= this.TankCapacity)
            {
                this.FuelQuantity += liters;
            }
            else
            {
                throw new InvalidRefuelingException();
            }
        }
    }
}