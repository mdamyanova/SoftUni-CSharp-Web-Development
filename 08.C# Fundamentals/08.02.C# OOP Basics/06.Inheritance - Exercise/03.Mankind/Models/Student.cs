using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Mankind.Models
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (IsNumberInvalid(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        private static bool IsNumberInvalid(string value)
        {
            bool isNumberInvalid = false;

            string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

            var regex = new Regex(numberPattern);

            var match = regex.Match(value);

            if (match.Success)
            {
                return isNumberInvalid;
            }

            return !isNumberInvalid;
        }
        

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {base.FirstName}");
            sb.AppendLine($"Last Name: {base.LastName}");
            sb.AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}