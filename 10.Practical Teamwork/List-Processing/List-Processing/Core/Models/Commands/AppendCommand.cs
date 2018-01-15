namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;

    public class AppendCommand : Command
    {
        public AppendCommand(IList<string> parameters) 
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            data.DataParams.Add(this.Parameters[0]);
        }
    }
}