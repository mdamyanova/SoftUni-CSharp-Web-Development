namespace BashSoft.Contracts
{
    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string username);
        void GetAllStudentsFromCourse(string courseName);
    }
}