namespace _01.Logger.Interfaces
{
    public interface ILogger
    {
        void Info(string msg);

        void Warn(string msg);

        void Error(string msg);

        void Critical(string msg);

        void Fatal(string msg);
    }
}