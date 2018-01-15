namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;

    public class PrependCommand : Command
    {
        public PrependCommand(IList<string> parameters) 
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            data.DataParams.Insert(0, this.Parameters[0]);
        }
    }
}