namespace List_Processing.Core.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ICommand
    {
        IList<string> Parameters { get; }
        void Execute(Data data);
        bool IsPrintable { get; }
    }
}