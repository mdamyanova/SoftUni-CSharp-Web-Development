namespace List_Processing.Core.Models.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;

    public class InsertCommand : Command
    {
        public InsertCommand(IList<string> parameters)
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

            var word = this.Parameters[1];

            data.DataParams.Insert(index, word);
        }
    }
}