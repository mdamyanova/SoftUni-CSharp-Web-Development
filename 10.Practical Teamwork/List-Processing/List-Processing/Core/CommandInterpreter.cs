namespace List_Processing.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Helpers;
    using Models;
    using Models.Commands;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly Logger logger;

        public CommandInterpreter(Logger logger)
        {
            this.logger = logger;
        }

        public Command ParseCommand(string commandInput)
        {           
            var commandArguments = commandInput.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            // first check if it's a valid command

            var length = commandArguments.Length;

            Command command = null;

            var action = commandArguments[0];
            var parameters = commandArguments.Skip(1).ToList();


            // make it with reflection, if you hate your life
            switch (action)
            {
                case "append":
                    ValidateCommandLength(length, Constants.AppendCommandLength);
                    command = new AppendCommand(parameters);
                    break;

                case "prepend":
                    ValidateCommandLength(length, Constants.PrependCommandLength);      
                    command = new PrependCommand(parameters);
                    break;

                case "reverse":
                    ValidateCommandLength(length, Constants.ReverseCommandLength);
                    command = new ReverseCommand(parameters);
                    break;

                case "insert":
                    ValidateCommandLength(length, Constants.InsertCommandLength);
                    command = new InsertCommand(parameters);
                    break;
                case "delete":
                    ValidateCommandLength(length, Constants.DeleteCommandLength);
                    command = new DeleteCommand(parameters);
                    break;

                case "roll":
                    ValidateCommandLength(length, Constants.RollCommandLength);
                    command = new RollCommand(parameters);
                    break;

                case "sort":
                    ValidateCommandLength(length, Constants.SortCommandLength);
                    command = new SortCommand(parameters);
                    break;

                case "count":
                    break;

                case "end":
                    this.logger.Write(Constants.FinishedMessage);
                    command = new EndCommand(parameters);
                    break;

                default:
                    throw new ArgumentException(Constants.InvalidCommand);
            }

            return command;
        }

        private static void ValidateCommandLength(int length, int reqLength)
        {
            var isCommandLengthValid = IsCommandLengthValid(length,
                reqLength);

            if (!isCommandLengthValid)
            {
                throw new ArgumentException(Constants.InvalidParameters);
            }
        }

        private static bool IsCommandLengthValid(int length, int reqLength)
        {
            return Utils.CheckCommandLength(
                length,
                reqLength);
        }
    }
}