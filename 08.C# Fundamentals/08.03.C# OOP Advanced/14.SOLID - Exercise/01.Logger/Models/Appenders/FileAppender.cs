namespace _01.Logger.Models.Appenders
{
    using System;
    using System.IO;
    using _01.Logger.Interfaces;

    public class FileAppender : Appender
    {
        private readonly StreamWriter writer;

        public FileAppender(string path, ILayout layout)
            : base(layout)
        {
            this.Path = path;
            this.writer = new StreamWriter(this.Path, true);
        }

        public string Path { get; set; }

        public override void Append(string message, ReportLevel level, DateTime dateTime)
        {
            var output = this.Layout.Format(message, level, dateTime);
            this.writer.WriteLine(output);
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}