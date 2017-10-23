using System;

namespace _01.SoftUniAirline
{
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniAirline
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<decimal> profits = new List<decimal>();

            for (int i = 0; i < n; i++)
            {
                int adultPassengers = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());

                int youthPassengers = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());

                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());

                int flightDuration = int.Parse(Console.ReadLine());

                decimal income = (adultPassengers * adultTicketPrice) + (youthPassengers * youthTicketPrice);
                decimal expenses = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;
                decimal profit = income - expenses;

                if (income >= expenses)
                {
                    Console.WriteLine($"You are ahead with {profit:0.000}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {profit:0.000}$.");
                }

                profits.Add(profit);
            }
                        
            Console.WriteLine($"Overall profit -> {profits.Sum():0.000}$.\nAverage profit -> {profits.Average():0.000}$.");
        }
    }
}