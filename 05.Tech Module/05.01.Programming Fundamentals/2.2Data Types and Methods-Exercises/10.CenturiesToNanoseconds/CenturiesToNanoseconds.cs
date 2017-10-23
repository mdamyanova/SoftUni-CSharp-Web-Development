using System;

namespace _10.CenturiesToNanoseconds
{
    public class CenturiesToNanoseconds
    {
        public static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = 24 * days;
            decimal minutes = 60m * hours;
            decimal seconds = 60m * minutes;
            decimal milliseconds = 1000m * seconds;
            decimal microseconds = 1000m * milliseconds;
            decimal nanoseconds = 1000m * microseconds;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours}" +
                $" hours = {minutes} minutes = {seconds} seconds" + 
                $" = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}