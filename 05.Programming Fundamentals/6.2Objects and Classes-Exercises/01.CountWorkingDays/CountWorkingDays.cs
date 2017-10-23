using System;

namespace _01.CountWorkingDays
{
    using System.Globalization;
    using System.Linq;

    public class CountWorkingDays
    {
        public static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] officialDays = new[]
                                          {
                                              new DateTime(startDate.Year, 1, 1),
                                              new DateTime(startDate.Year, 3, 3),
                                              new DateTime(startDate.Year, 5, 1),
                                              new DateTime(startDate.Year, 5, 6),
                                              new DateTime(startDate.Year, 5, 24),
                                              new DateTime(startDate.Year, 9, 6),
                                              new DateTime(startDate.Year, 9, 22),
                                              new DateTime(startDate.Year, 11, 1),
                                              new DateTime(startDate.Year, 12, 24),
                                              new DateTime(startDate.Year, 12, 25),
                                              new DateTime(startDate.Year, 12, 26)
                                          };
            
            int workingDaysCounter = 0;

            for (DateTime start = startDate; start <= endDate; start = start.AddDays(1))
            {
                var currDate = start.Date;
                var currDay = start.DayOfWeek;
                if ((currDay != DayOfWeek.Saturday) && (currDay != DayOfWeek.Sunday) && (!officialDays.Contains(currDate)))
                {
                    workingDaysCounter++;
                }
            }

            Console.WriteLine(workingDaysCounter);
        }
    }
}