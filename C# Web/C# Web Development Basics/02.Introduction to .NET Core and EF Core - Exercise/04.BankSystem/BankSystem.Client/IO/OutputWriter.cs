namespace BankSystem.Client.IO
{
    using System;

    public class OutputWriter
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}