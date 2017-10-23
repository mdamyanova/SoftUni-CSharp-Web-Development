namespace _01.Logger.Models
{
    using System;
    using _01.Logger.Interfaces;

    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            Appender = appender;
        }

        public static IAppender Appender { get; private set; }

        public void Info(string msg)
        {
            this.Log(msg, ReportLevel.Info);
        }

        public void Warn(string msg)
        {
            this.Log(msg, ReportLevel.Warn);
        }

        public void Error(string msg)
        {
            this.Log(msg, ReportLevel.Error);
        }

        public void Critical(string msg)
        {
            this.Log(msg, ReportLevel.Critical);
        }

        public void Fatal(string msg)
        {
            this.Log(msg, ReportLevel.Fatal);
        }

        private void Log(string msg, ReportLevel level)
        {
            var date = DateTime.Now;
            Appender.Append(msg, level, date);
        }
    }
}