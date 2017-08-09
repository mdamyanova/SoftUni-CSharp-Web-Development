namespace _01.Logger.Models.Appenders
{
    using System;
    using _01.Logger.Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Layout cannot be null");
                }
                this.layout = value;
            }
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string message, ReportLevel level, DateTime dateTime);
    }
}