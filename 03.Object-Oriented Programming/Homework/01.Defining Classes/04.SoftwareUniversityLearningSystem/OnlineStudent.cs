namespace _04.SoftwareUniversityLearningSystem
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, int studentNumber, int averageGrade, string currentCourse) :
            base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
        }
    }
}