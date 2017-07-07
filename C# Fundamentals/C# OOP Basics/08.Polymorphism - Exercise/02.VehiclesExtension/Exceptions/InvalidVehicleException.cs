using System;

namespace _02.VehiclesExtension.Exceptions
{
    public class InvalidVehicleException : Exception
    {
        private const string InvalidVehicle = "Invalid vehicle.";

        public InvalidVehicleException()
            : base ()
        {

        }

        public InvalidVehicleException(string message)
            : base (message)
        {

        }
    }
}