namespace _01.Logger.Models.Layouts
{
    using System;
    using _01.Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string message, ReportLevel level, DateTime dateTime)
        {
            return $"{dateTime} - {level} - {message}";
        }
    }
}