namespace _02.VehiclesExtension.Exceptions
{
    public class InvalidDriveException : InvalidVehicleException
    {
        private const string Drive = "needs refueling";

        public InvalidDriveException()
            : base(Drive)
        {

        }

        public InvalidDriveException(string message)
            : base(message)
        {

        }
    }
}