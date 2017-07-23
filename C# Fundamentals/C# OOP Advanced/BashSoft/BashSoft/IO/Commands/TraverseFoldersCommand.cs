using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.Static_data;

namespace BashSoft.IO.Commands
{
    public class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentsRepository repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            switch (this.Data.Length)
            {
                case 1:
                    this.InputOutputManager.TraverseDirectory(0);
                    break;
                case 2:
                    var depth = 0;
                    var hasParsed = int.TryParse(this.Data[1], out depth);

                    if (hasParsed)
                    {
                        this.InputOutputManager.TraverseDirectory(depth);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                    }
                    break;
                default:
                    throw new InvalidCommandException(this.Input);
            }
        }
    }
}