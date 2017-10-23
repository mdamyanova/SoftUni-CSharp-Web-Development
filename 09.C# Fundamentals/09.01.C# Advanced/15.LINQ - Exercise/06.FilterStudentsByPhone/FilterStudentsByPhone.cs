using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FilterStudentsByPhone
{
    public class FilterStudentsByPhone
    {
        public static void Main()
        {           
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (input != "END")
            {
                var tokens = input.Split();
                var student = new Student()
                {
                    FirstName = tokens[0],
                    LastName = tokens[1],
                    Phone = tokens[2]
                };

                students.Add(student);

                input = Console.ReadLine();
            }

            students = students.Where(st => st.Phone.StartsWith("02") ||
                                      st.Phone.StartsWith("+3592"))
                                      .ToList();

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
        public string Phone { get; set; }
    }
}