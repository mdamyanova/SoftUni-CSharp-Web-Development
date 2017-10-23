namespace Huy_Phuong.CommandManager
{
    using System;
    using System.Globalization;

    public class AddPerformance
    {
        public static string ExecuteAddPerformanceCommand(string[] performanceParams)
        {
            var theatre = performanceParams[0];
            var performanceTitle = performanceParams[1];
            var dateTime = DateTime.ParseExact(performanceParams[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var startDateTime = dateTime;
            var duration = TimeSpan.Parse(performanceParams[3]);
            var price = decimal.Parse(performanceParams[4], NumberStyles.Float);

            MainProgram.Database.AddPerformance(theatre, performanceTitle, startDateTime, duration, price);

            return "Performance added";
        }
    }
}