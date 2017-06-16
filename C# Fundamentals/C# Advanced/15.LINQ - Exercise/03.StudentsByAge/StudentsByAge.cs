using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StudentsByAge
{
    public class StudentsByAge
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
                    Age = int.Parse(tokens[2])
                };

                students.Add(student);

                input = Console.ReadLine();
            }

            students = students.Where(st => st.Age >= 18 && st.Age <= 24).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}