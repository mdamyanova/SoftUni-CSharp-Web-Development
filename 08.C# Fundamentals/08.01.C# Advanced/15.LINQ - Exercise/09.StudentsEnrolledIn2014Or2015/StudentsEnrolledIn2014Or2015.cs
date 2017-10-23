using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.StudentsEnrolledIn2014Or2015
{
    public class StudentsEnrolledIn2014Or2015
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (input != "END")
            {
                var studentInfo = input.Split();
                var facultyNumber = studentInfo[0];
                var marks = new List<byte>();

                for (int i = 1; i < studentInfo.Length; i++)
                {
                    marks.Add(byte.Parse(studentInfo[i]));
                }

                var student = new Student
                {
                    FacultyNumber = facultyNumber,
                    Marks = marks
                };

                students.Add(student);

                input = Console.ReadLine();
            }

            students = students.Where(st => st.FacultyNumber.EndsWith("14") ||
                                      st.FacultyNumber.EndsWith("15")).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(string.Join(" ", student.Marks));
            }
        }
    }

    public class Student
    {
        public string FacultyNumber { get; set; }
        public List<byte> Marks { get; set; }
    }
}