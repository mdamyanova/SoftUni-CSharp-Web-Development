namespace ConsoleLogger
{
    using System;
    using System.IO;

    public class ConsolePrinter
    {
        private IWriter writer;

        public ConsolePrinter(IWriter writer)
        {
            this.writer = writer;
        }

        public void Print(string message)
        {
            this.writer.WriteLine(message);
        }
    }

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileWriter : IWriter
    {
        public void WriteLine(string message)
        {
            using (var streamWriter = new StreamWriter("file.txt"))
            {
                streamWriter.WriteLine(message);
            }
        }
    }

    public interface IWriter
    {
        void WriteLine(string message);
    }
}