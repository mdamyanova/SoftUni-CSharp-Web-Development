using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking = new HashSet<string>();

            while (input != "END")
            {
                var inputParams = Regex.Split(input, ", ");
                if (inputParams[0] == "IN")
                {
                    parking.Add(inputParams[1]);
                }
                else
                {
                   parking.Remove(inputParams[1]);
                }

                input = Console.ReadLine();
            }
			
			if(parking.Count == 0)
			{
				Console.WriteLine("Parking Lot is Empty");
			}
			else 
			{
				foreach(var car in parking)
				{
					Console.WriteLine(car);
				}
			}
        }
    }
}