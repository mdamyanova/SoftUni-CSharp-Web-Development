using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.GroupByGroup
{
    public class GroupByGroup
    {
        public static void Main()
        {           
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (input != "END")
            {
                var studentInfo = input.Split();
                var fullName = studentInfo[0] + " " + studentInfo[1];
                var group = studentInfo[2];

                var student = new Student
                {
                    FullName = fullName,
                    Group = int.Parse(group)
                };

                students.Add(student);

                input = Console.ReadLine();
            }

            var groupedStudents = students.GroupBy(st => st.Group).OrderBy(st => st.Key);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine(group.Key + " - " + string.Join(", ", group.Select(n => n.FullName)));
            }
        }
    }

    public class Student
    {
        public string FullName { get; set; }
        public int Group { get; set; }
    }
}