namespace _02.VehiclesExtension.Exceptions
{
    public class InvalidRefuelingException : InvalidVehicleException
    {
        private const string Refueling = "Cannot fit fuel in tank";

        public InvalidRefuelingException()
            : base(Refueling)
        {

        }

        public InvalidRefuelingException(string message)
            : base(message)
        {

        }
    }
}