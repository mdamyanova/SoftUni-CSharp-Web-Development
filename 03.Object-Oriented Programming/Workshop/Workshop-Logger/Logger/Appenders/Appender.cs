using System;
using Logger.Interfaces;

namespace Logger
{
    public abstract class Appender : IAppender
    {
        private IFormatter formatter;

        protected Appender(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        public IFormatter Formatter
        {
            get { return this.formatter; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Formatter cannot be null");
                }
                this.formatter = value;
            }
        }

        public abstract void Append(string msg, ReportLevel level, DateTime date);
    }
}