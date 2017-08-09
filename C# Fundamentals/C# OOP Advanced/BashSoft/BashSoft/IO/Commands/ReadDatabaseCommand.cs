using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;

    [Alias("readdb")]
    public class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);            
            }

            var fileName = this.Data[1];
            this.Repository.LoadData(fileName);
        }
    }
}