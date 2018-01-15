namespace List_Processing.Core.Models.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;

    public class RollCommand : Command
    {
        private const int ShiftAmount = 1;

        public RollCommand(IList<string> parameters) 
            : base(parameters)
        {
        }

        public override void Execute(Data data)
        {
            var direction = this.Parameters[0];

            var length = data.DataParams.Count;

            var shiftedData = new List<string>(data.DataParams);

            if (direction == "right")
            {
                for (int i = 0; i < length; i++)
                {
                    shiftedData[(i + ShiftAmount) % length] = data.DataParams[i];

                }

            }
            else if (direction == "left")
            {
                for (int i = 0; i < length; i++)
                {
                    shiftedData[i] = data.DataParams[(i + ShiftAmount) % length];

                }
            }
            else
            {
                throw new ArgumentException($"{Constants.InvalidParameters}");
            }

            data.DataParams = shiftedData;
        }
    }
}