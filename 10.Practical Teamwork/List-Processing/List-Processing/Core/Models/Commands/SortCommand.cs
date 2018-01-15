namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;

    public class SortCommand : Command
    {
        public SortCommand(IList<string> parameters) 
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            data.DataParams.Sort();
        }
    }
}