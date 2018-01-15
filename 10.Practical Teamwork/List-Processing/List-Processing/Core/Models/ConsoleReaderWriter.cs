namespace List_Processing.Core.Models
{
    using System;

    public class ConsoleLogger : Logger
    {
        public override string Read()
        {
            var line = Console.ReadLine();

            return line;
        }

        public override void Write(string line)
        {
            Console.WriteLine(line);
        }
    }
}