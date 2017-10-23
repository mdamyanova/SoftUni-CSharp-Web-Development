namespace _04.SoftwareUniversityLearningSystem
{
    public class CurrentStudent : Student
    {
        public string CurrentCourse { get; set; }

        public CurrentStudent(string firstName, string lastName, int age, int studentNumber, int averageGrade, string currentCourse) :
            base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }
    }
}