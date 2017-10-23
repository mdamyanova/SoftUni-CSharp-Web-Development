using System;

namespace BashSoft.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "The command {0} is invalid.";

        public InvalidCommandException(string input) : base(string.Format(InvalidCommand, input))
        {
            
        }
    }
}