namespace _01.Logger.Interfaces
{
    using System;
    using _01.Logger.Models;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string message, ReportLevel level, DateTime dateTime);
    }
}