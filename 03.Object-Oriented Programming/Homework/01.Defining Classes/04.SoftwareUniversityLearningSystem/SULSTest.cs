using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftwareUniversityLearningSystem
{
    class SULSTest
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Trainer("Mariq", "Mariikova", 25));
            persons.Add(new GraduateStudent("Sashka", "Todorova", 33, 400007422, 4));
            persons.Add(new CurrentStudent("Ivan", "Ivanov", 19, 0052197, 5, "Advanced C#"));
            persons.Add(new DropoutStudent("Kolio", "Kolev", 29, 99942756, 5, "Too smart"));
            persons.Add(new OnlineStudent("Bendjamin", "Karatarambukov", 17, 4511009, 3, "OOP"));
            persons.Add(new OnsiteStudent("Dimka", "Dimitrova", 40, 3562550, 5, "OOP", 4));
            persons.Add(new CurrentStudent("Ivana", "Emilova", 20, 51973, 5, "OOP"));
            persons.Add(new CurrentStudent("Georgi", "Goshev", 27, 6372063, 6, "Java Fundamentals"));

            persons.OfType<CurrentStudent>()
                .OrderByDescending(s => s.AverageGrade)
                .ToList()
                .ForEach(s => Console.WriteLine($"Student name: {s.FirstName} {s.LastName}\n" +
                                                $"Age: {s.Age}\n" +
                                                $"Student number: {s.StudentNumber}\n" +
                                                $"Average grade: {s.AverageGrade}\n" +
                                                $"Current course: {s.CurrentCourse}\n"));
        }
    }
}