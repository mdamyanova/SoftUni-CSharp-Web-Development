using System;
using Logger.Interfaces;

namespace Logger.Formatters
{
    public class SimpleFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
           return $"{date} - {level} - {msg}";
        }
    }
}