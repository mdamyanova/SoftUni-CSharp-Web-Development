namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        private const string Message = "Invalid song length.";

        public InvalidSongLengthException() : base(Message)
        {
        }

        public InvalidSongLengthException(string message) : base(message)
        {
        }
    }
}