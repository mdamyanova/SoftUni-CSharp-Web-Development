namespace Logger.Models.Appenders
{
    using System;

    using global::Logger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string message, ReportLevel level, DateTime dateTime)
        {
            var output = this.Layout.Format(message, level, dateTime);
            Console.WriteLine(output);
        }
    }
}