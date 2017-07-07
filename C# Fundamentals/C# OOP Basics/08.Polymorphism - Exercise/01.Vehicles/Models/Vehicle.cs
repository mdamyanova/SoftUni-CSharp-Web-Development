namespace _01.Vehicles.Models
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);
    }
}