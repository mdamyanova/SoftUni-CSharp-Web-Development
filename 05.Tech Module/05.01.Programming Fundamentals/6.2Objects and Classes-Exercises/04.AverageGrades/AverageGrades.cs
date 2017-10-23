using System;
using System.Linq;

namespace _04.AverageGrades
{
    using System.Collections.Generic;

    public class AverageGrades
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                students.Add(Student.ReadStudent());
            }

            foreach (var student in students.Where(s => s.AverageGrade >= 5.00).OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrade))
            {
                Console.WriteLine(student);
            }
        }
    }
}

public class Student
{
    public string Name { get; set; }

    public double[] Grades { get; set; }

    public double AverageGrade => this.Grades.Average();

    public static Student ReadStudent()
    {
        string[] args = Console.ReadLine().Split();

        var student = new Student();
        student.Name = args[0];
        student.Grades = new double[args.Length - 1];

        for (int i = 1; i < args.Length; i++)
        {
            student.Grades[i - 1] = double.Parse(args[i]);
        }

        return student;
    }

    public override string ToString()
    {
        return $"{this.Name} -> {this.AverageGrade:f2}";
    }
}