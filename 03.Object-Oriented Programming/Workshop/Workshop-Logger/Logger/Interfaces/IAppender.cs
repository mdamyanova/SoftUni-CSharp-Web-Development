using System;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        IFormatter Formatter { get; set; }

        void Append(string msg, ReportLevel level, DateTime date);
    }
}