namespace Logger.Interfaces
{
    using System;

    using Logger.Models;

    public interface ILayout
    {
        string Format(string message, ReportLevel level, DateTime dateTime);
    }
}