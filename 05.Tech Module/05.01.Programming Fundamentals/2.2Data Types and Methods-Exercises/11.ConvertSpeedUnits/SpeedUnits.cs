using System;

namespace _11.ConvertSpeedUnits
{
    public class SpeedUnits
    {
        public static void Main()
        {
            float distanceMeters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float hourTime = hours + minutes / 60.0f + seconds / 3600.0f;
            float kmSpeed = (distanceMeters / 1000.0f) / hourTime;
            float metersSpeed = kmSpeed / 3.6f;
            float milesSpeed = (distanceMeters / 1609.0f) / hourTime;

            Console.WriteLine($"{metersSpeed}\n{kmSpeed}\n{milesSpeed}");

        }
    }
}