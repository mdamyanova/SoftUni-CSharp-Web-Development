namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;

    public class EndCommand : Command
    {
        public EndCommand(IList<string> parameters)
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            data.EndReceived = true;
        }
    }
}