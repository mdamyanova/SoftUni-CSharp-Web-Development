using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem;

namespace _01.StudentSystem
{
    class Startup
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            //01. List all students 
            //ListStudents(context);

            //02. List all courses
            //ListCourses(context);

            //03. List all courses with more than 5 resources
            //ListCoursesWithMoreThan5Resources(context);

            //04. List courses with given date
            //var date = new DateTime(2017, 3, 6);
            //ListCoursesFromDate(date, context);

            //05. List students by courses
            //ListStudentsByCourses(context);
        }

        private static void ListStudents(StudentSystemContext context)
        {
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                var homeworkSubmissions = context.Homeworks.Where(h => h.Student.Name == student.Name).Select(h => h);
                foreach (var homeworkSubmission in homeworkSubmissions)
                {
                    Console.WriteLine($"{homeworkSubmission.Content} - {homeworkSubmission.ContentType}");
                }
            }
        }

        private static void ListCourses(StudentSystemContext context)
        {
            var courses = context.Courses.OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate).ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Description}");
                var resources = context.Resources.Where(r => r.Course.Name == course.Name).Select(r => r).ToList();
                foreach (var resource in resources)
                {
                    Console.WriteLine($"{resource.Id} {resource.Name} {resource.ResourceType} {resource.Url}");
                }
            }
        }

        private static void ListCoursesWithMoreThan5Resources(StudentSystemContext context)
        {
            var courses = context.Courses.Where(c => c.Resources.Count() > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Name}: {c.Resources} resources");
            }
        }

        private static void ListCoursesFromDate(DateTime date, StudentSystemContext context)
        {
            context.Courses
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .OrderByDescending(c => c.Students.Count)
                .ToList()
                .OrderByDescending(c => c.EndDate.Subtract(c.StartDate).Days)
                .ToList()
                .ForEach(
                    c =>
                        Console.WriteLine(
                            $"Course name: {c.Name}\nStart date: {c.StartDate}\nEnd date: {c.EndDate} " +
                            $"\nDuration: {c.EndDate.Subtract(c.StartDate).Days}\nStudents enrolled: {c.Students.Count}"));
        }

        private static void ListStudentsByCourses(StudentSystemContext context)
        {
            foreach (var student in context.Students
                .OrderByDescending(x => x.Courses.Sum(z => z.Price))
                .ThenByDescending(x => x.Courses.Count)
                .ThenBy(x => x.Name))
            {
                Console.WriteLine($"{student.Name}\nNumber of courses: {student.Courses.Count}" +
                                  $"\nTotal price: {student.Courses.Sum(c => c.Price)}\nAverage price:{student.Courses.Average(c => c.Price)}");
            }
        }
    }
}
