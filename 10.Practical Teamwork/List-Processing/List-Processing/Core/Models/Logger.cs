namespace List_Processing.Core.Models
{
    using Contracts;

    public abstract class Logger : IReader, IWriter
    {
        public abstract string Read();

        public abstract void Write(string line);
    }
}