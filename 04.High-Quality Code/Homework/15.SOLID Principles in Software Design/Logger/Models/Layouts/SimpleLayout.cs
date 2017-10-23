namespace Logger.Models.Layouts
{
    using System;

    using global::Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string message, ReportLevel level, DateTime dateTime)
        {
            return $"{dateTime} - {level} - {message}";
        }
    }
}