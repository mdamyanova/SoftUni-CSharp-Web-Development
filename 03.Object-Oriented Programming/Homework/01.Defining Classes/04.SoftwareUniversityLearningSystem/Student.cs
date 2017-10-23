namespace _04.SoftwareUniversityLearningSystem
{
    public class Student : Person
    {
        public int StudentNumber { get; set; }

        public int AverageGrade { get; set; }

        public Student(string firstName, string lastName, int age, int studentNumber, int averageGrade) :
            base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }
    }
}