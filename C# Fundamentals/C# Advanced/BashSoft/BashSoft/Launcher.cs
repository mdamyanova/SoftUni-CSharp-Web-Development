namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoreFromCourse("Unity", "Ivan");
        }
    }
}