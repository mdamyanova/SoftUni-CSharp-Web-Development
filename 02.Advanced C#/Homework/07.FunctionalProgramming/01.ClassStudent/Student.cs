using System.Collections.Generic;

namespace _01.ClassStudent
{
    public class Student
    {
        public Student
            (
            string firstName,
            string lastName,
            int age,
            string facultyNumber,
            string phone,
            string email,
            IList<int> marks,
            int groupNumber
            )
            
        {
         
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
           
        }
    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FacultyNumber { get; set; }

        public int Age { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public IList<int> Marks { get; private set; }

        public int GroupNumber { get; private set; }
       
    }
}