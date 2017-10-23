using System;
using Logger;
using Logger.Interfaces;

namespace ConsoleAppTest
{
    public class JsonFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            return $"{{ {date} {msg} {level} }}";
        }
    }
}