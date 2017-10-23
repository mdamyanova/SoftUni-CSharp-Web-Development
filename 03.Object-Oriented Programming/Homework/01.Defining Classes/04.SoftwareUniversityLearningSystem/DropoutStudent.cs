using System;

namespace _04.SoftwareUniversityLearningSystem
{
    public class DropoutStudent : Student
    {
        public string DropoutReason { get; set; }

        public DropoutStudent(string firstName, string lastName, int age, int studentNumber, int averageGrade, string dropoutReason) : 
            base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public void ReApply()
        {
            Console.WriteLine($"Student name: {this.FirstName} {this.LastName}\n" +
                              $"Age: {this.Age}\nStudent number: {this.StudentNumber}\n" +
                              $"Average grade: {this.AverageGrade}\nDropout reason: {this.DropoutReason}\n");
        }
    }
}