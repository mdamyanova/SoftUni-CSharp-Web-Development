using System;
using BashSoft.Contracts;
using BashSoft.Static_data;

namespace BashSoft.IO
{
    public class InputReader : IReader
    {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                var input = Console.ReadLine().Trim();

                if (input == endCommand)
                {
                    break;
                }
           
                this.interpreter.InterpretCommand(input);
            }
        }
    }
}