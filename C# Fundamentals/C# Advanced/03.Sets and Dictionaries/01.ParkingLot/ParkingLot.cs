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
                else if (inputParams[0] == "OUT")
                {
                    if (parking.Contains(inputParams[1]))
                    {
                        parking.Remove(inputParams[1]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(parking.Any() ? string.Join("\n", parking) : "Parking Lot is Empty");
        }
    }
}