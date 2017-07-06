namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        private const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException() : base(Message)
        {
        }

        public InvalidSongNameException(string message) : base(message)
        {
        }
    }
}