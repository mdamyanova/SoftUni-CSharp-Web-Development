using System;

namespace _04.SoftwareUniversityLearningSystem
{
    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) : 
            base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string courseName)
        {
            this.CourseName = courseName;
            Console.WriteLine($"{this.CourseName} has been deleted");
        }
    }
}