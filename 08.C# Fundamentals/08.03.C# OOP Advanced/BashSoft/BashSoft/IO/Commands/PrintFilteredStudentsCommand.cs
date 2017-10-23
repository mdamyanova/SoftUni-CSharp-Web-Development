using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;

    [Alias("filter")]
    public class PrintFilteredStudentsCommand : Command
    {
        public PrintFilteredStudentsCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            var courseName = this.Data[1];
            var filter = this.Data[2];
            var takeCommand = this.Data[3].ToLower();
            var takeQuantity = this.Data[4].ToLower();

            ParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
        }

        private void ParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand != "take")
            {
                throw new InvalidCommandException(takeCommand);
            }

            if (takeQuantity == "all")
            {
                this.Repository.FilterAndTake(courseName, filter);
            }
            else
            {
                int studentsToTake;
                var hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                if (hasParsed)
                {
                    this.Repository.FilterAndTake(courseName, filter, studentsToTake);
                }
                else
                {
                    throw new InvalidCommandException(takeQuantity);
                }
            }
        }
    }
}