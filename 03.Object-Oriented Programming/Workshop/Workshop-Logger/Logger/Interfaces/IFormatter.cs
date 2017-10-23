using System;

namespace Logger.Interfaces
{
    public interface IFormatter
    {
        string Format(string msg, ReportLevel level, DateTime date);
    }
}