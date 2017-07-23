using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            switch (this.Data.Length)
            {
                case 2:
                {
                    var courseName = this.Data[1];
                    this.Repository.GetAllStudentsFromCourse(courseName);
                }
                    break;
                case 3:
                {
                    var courseName = this.Data[1];
                    var userName = this.Data[2];
                    this.Repository.GetStudentScoresFromCourse(courseName, userName);
                }
                    break;
                default:
                    throw new InvalidCommandException(this.Input);
            }
        }
    }
}