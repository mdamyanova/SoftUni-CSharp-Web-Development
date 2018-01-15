namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Command : ICommand
    {
        protected Command(IList<string> parameters)
        {
            this.Parameters = parameters;
        }

        //public string Action { get; set; }

        public IList<string> Parameters { get; set; }

        public abstract void Execute(Data data);
    }
}