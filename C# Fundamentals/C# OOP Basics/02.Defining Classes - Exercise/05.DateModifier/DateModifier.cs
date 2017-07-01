using System;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public static double FindDifferenceOfDays(string firstDate, string secondDate)
        {
            var date1 = DateTime.Parse(firstDate);
            var date2 = DateTime.Parse(secondDate);

            return Math.Abs((date2 - date1).TotalDays);
        }
    }
}