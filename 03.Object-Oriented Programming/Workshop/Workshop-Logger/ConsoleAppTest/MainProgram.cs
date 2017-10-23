using Logger;
using Logger.Interfaces;

namespace ConsoleAppTest
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            IFormatter formatter = new JsonFormatter();
            var appender = new FileAppender("file.txt", formatter);
            var logger = new global::Logger.Logger(appender);
            var a = 5;
            try
            {
                logger.Critical("a cannot be 5");
                logger.Warn("b cannot be 5");
            }
            finally 
            {
                appender.Close();
            }
        }
    }
}