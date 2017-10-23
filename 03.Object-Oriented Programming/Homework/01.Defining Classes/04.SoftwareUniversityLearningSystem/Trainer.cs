using System;

namespace _04.SoftwareUniversityLearningSystem
{
    public class Trainer : Person
    {
        public string CourseName { get; set; }

        public Trainer(string firstName, string lastName, int age) : 
            base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            this.CourseName = courseName;
            Console.WriteLine($"{this.CourseName} has been created");
        }
    }
}