namespace BashSoft
{
    using System;

    public static class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input == endCommand)
                {
                    break;
                }
                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}