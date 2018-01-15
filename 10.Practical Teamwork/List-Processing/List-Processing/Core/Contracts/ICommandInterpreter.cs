namespace List_Processing.Core.Contracts
{
    using Models.Commands;

    public interface ICommandInterpreter
    {
        Command ParseCommand(string commandInput);
    }
}