using System;

namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        private const string Message = "Invalid song.";

        public InvalidSongException() : base(Message)
        {
        }

        public InvalidSongException(string message) : base(message)
        {
        }
    }
}