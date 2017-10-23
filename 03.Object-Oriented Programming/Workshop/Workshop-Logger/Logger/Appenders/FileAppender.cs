using System;
using System.IO;
using Logger.Interfaces;

namespace Logger
{
    public class FileAppender : Appender
    {
        private StreamWriter writer;

        public FileAppender(string path, IFormatter formatter) : base(formatter)
        {
            this.Path = path;
            this.writer = new StreamWriter(this.Path, true);
        }

        public string Path { get; set; }

        public override void Append(string msg, ReportLevel level, DateTime date)
        {
            var output = this.Formatter.Format(msg, level, date);
            this.writer.WriteLine(output);        
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}