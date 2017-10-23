using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;

    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data) : base (input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);              
            }

            this.Judge.CompareContent(this.Data[1], this.Data[2]);
        }
    }
}