namespace _01.SchoolCompetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SchoolCompetition
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var studentsPoints = new Dictionary<string, int>();
            var studentsCategories = new Dictionary<string, SortedSet<string>>();

            while (line != "END")
            {
                var tokens = line.Split();
                var name = tokens[0];
                var category = tokens[1];
                var points = int.Parse(tokens[2]);

                if (!studentsPoints.ContainsKey(name))
                {
                    studentsPoints[name] = 0;
                }

                studentsPoints[name] += points;

                if (!studentsCategories.ContainsKey(name))
                {
                    studentsCategories[name] = new SortedSet<string>();
                }

                studentsCategories[name].Add(category);

                line = Console.ReadLine();
            }

            var orderedStudents = studentsPoints.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key);
            
            foreach (var student in orderedStudents)
            {
                var studentCategoriesText = string.Join(", ", studentsCategories[student.Key]);
                Console.WriteLine($"{student.Key}: {student.Value} [{studentCategoriesText}]");
            }
        }
    }
}