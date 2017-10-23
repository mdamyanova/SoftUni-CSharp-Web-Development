namespace _01.Logger.Interfaces
{
    using System;
    using _01.Logger.Models;

    public interface ILayout
    {
        string Format(string message, ReportLevel level, DateTime dateTime);
    }
}