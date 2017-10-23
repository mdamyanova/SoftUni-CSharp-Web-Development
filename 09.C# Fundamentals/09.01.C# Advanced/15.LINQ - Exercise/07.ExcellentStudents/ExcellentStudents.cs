using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ExcellentStudents
{
    public class ExcellentStudents
    {
        public static void Main()
        {          
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (input != "END")
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var marks = new List<byte>();

                for (int i = 2; i < studentInfo.Length; i++)
                {
                    marks.Add(byte.Parse(studentInfo[i]));
                }

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Marks = marks
                };

                students.Add(student);

                input = Console.ReadLine();
            }

            students = students.Where(st => st.Marks.Contains(6)).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<byte> Marks { get; set; }
    }
}