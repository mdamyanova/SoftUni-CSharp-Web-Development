
namespace _04.SoftwareUniversityLearningSystem
{
    public class OnsiteStudent : CurrentStudent
    {
        public int NumberOfVisits { get; set; }

        public OnsiteStudent(string firstName, string lastName, int age, int studentNumber, int averageGrade, string currentCourse, int numberOfVisits) :
            base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }
    }
}