namespace _02.VehiclesExtension.Exceptions
{
    public class InvalidTankCapacityException : InvalidVehicleException
    {
        private const string TankCapacity = "Fuel must be a positive number";

        public InvalidTankCapacityException()
            : base(TankCapacity)
        {

        }

        public InvalidTankCapacityException(string message)
            : base(message)
        {

        }
    }
}