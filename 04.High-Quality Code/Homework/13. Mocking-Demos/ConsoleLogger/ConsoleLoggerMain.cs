namespace ConsoleLogger
{
    public class ConsoleLoggerMain
    {
        static void Main()
        {
            var writer = new ConsoleWriter();
            var logger = new ConsolePrinter(writer);
            logger.Print("Invalid operation exception");
        }
    }
}