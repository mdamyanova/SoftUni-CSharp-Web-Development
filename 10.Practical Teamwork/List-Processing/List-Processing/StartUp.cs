namespace List_Processing
{
    using Core;
    using Core.Models;

    public class StartUp
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var interpreter = new CommandInterpreter(logger);

            var engine = new Engine(logger, interpreter);

            engine.Run();
        }
    }
}