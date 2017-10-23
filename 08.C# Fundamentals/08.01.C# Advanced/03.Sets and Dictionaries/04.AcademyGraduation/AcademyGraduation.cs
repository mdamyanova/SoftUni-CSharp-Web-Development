using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var academy = new SortedDictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                var studentName = Console.ReadLine();
                var studentGrades = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                academy.Add(studentName, studentGrades);
            }

            foreach (var student in academy)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}