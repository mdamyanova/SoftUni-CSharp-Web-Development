using System.Diagnostics;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Static_data;

namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;

    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}