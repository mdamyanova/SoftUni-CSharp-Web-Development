using System;
using BashSoft.Static_data;

namespace BashSoft.IO
{
    public class InputReader
    {
        private const string endCommand = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();

                if (input == endCommand)
                {
                    break;
                }
           
                this.interpreter.InterpredCommand(input);
            }
        }
    }
}