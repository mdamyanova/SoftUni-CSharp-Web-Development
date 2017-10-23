using System;

namespace _01.Human_StudentAndWorker
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) :
            base(firstName, lastName)
        {           
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 && value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number length must be in range [5...10]");
                }
                this.facultyNumber = value;
            }
        }
    }
}