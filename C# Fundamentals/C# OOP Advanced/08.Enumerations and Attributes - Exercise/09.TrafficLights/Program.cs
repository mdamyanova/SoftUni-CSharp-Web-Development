using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.TrafficLights
{
    public class Program
    {
        public static void Main()
        {
            var inputColors = Console.ReadLine().Split();
            var trafficLights = inputColors.Select(t => new TrafficLight((LightColor) Enum.Parse(typeof(LightColor), t))).ToList();
            var numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeColor();
                    Console.Write(trafficLight.CurrentColor + " ");
                }

                Console.WriteLine();
            }
        }
    }
}