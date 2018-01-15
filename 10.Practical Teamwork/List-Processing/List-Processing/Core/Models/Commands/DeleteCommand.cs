namespace List_Processing.Core.Models.Commands
{
    using System.Collections.Generic;
    using System;
    using List_Processing.Helpers;

    public class DeleteCommand : Command
    {
        public DeleteCommand(IList<string> parameters)
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            var indexString = this.Parameters[0];

            if (!int.TryParse(indexString, out int index))
            {
                throw new ArgumentException($"{Constants.InvalidIndex} {indexString}");
            }

            if (index < 0 || index >= data.DataParams.Count)
            {
                throw new ArgumentException($"{Constants.InvalidIndex} {indexString}");
            }

          data.DataParams.RemoveAt(index);
        }
    }
}