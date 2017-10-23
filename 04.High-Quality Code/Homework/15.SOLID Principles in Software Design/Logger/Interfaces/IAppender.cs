namespace Logger.Interfaces
{
    using System;

    using Logger.Models;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string message, ReportLevel level, DateTime dateTime);
    }
}