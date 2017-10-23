namespace StudentSystem.Client
{
    using System;
    using System.Linq;
    using StudentSystem.Data;

    public class CrudOperations
    {
        public static void ListAllStudentsAndHomeworks(StudentSystemDbContext context)
        {
            context
                .Homeworks
                .Select(h => new
                {
                    StudentName = h.Student.Name,
                    h.Content,
                    h.ContentType
                })
                .ToList()
                .ForEach(sh => Console.WriteLine($"Student name: {sh.StudentName};" + Environment.NewLine +
                                                 $"Content: {sh.Content}; Content type: {sh.ContentType}" +
                                                 Environment.NewLine));
        }

        public static void ListAllCoursesAndResources(StudentSystemDbContext context)
        {
            var result = context
                .Courses
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources,
                    c.StartDate,
                    c.EndDate
                })
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate);

            foreach (var course in result)
            {
                Console.WriteLine($"Course name: {course.Name}");
                Console.WriteLine($"Course description: {course.Description}");

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"Resource name: {resource.Name}");
                    Console.WriteLine($"Resource type: {resource.ResourceType}");
                    Console.WriteLine($"Resource url: {resource.Url}");
                }

                Console.WriteLine();
            }
        }

        public static void ListAllCoursesWithMoreThanFiveResources(StudentSystemDbContext context)
        {
            // changed to 1 to get some results print
            var moreThanResources = 1;

            context
                .Courses
                .Select(c => new
                {
                    c.Name,
                    Resources = c.Resources.Count,
                    c.StartDate
                })
                .Where(c => c.Resources >= moreThanResources)
                .OrderByDescending(c => c.Resources)
                .ThenByDescending(c => c.StartDate)
                .ToList()
                .ForEach(c => Console.WriteLine($"Course name: {c.Name}; Resources count: {c.Resources}" +
                                                Environment.NewLine));
        }

        public static void ListAllCoursesActiveOnGivenDate(StudentSystemDbContext context, DateTime date)
        {
            context.Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = c.EndDate.Subtract(c.StartDate).Days,
                    Students = c.Students.Count
                })
                .OrderByDescending(c => c.Students)
                .ThenByDescending(c => c.Duration)
                .ToList()
                .ForEach(
                    c =>
                        Console.WriteLine(
                            $"Course name: {c.Name}; Start date: {c.StartDate}; End date: {c.EndDate} " +
                            Environment.NewLine + $"Duration: {c.Duration}; Students enrolled: {c.Students}" +
                            Environment.NewLine));
        }

        public static void ListAllStudentsInformation(StudentSystemDbContext context)
        {
            context
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    Courses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Course.Price),
                    AveragePrice = s.Courses.Average(c => c.Course.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.Courses)
                .ThenBy(s => s.Name)
                .ToList()
                .ForEach(s => Console.WriteLine($"Student name: {s.Name}; Courses count: {s.Courses};" +
                                                $"Total price: {s.TotalPrice}; Average price: {s.AveragePrice}" +
                                                Environment.NewLine));
        }

        public static void ListAllCoursesWithResourcesAndLicenses(StudentSystemDbContext context)
        {
            var result = context
                .Courses
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Resources = c
                        .Resources
                        .OrderByDescending(r => r.Licenses.Count)
                        .ThenBy(r => r.Name)
                        .Select(r => new
                        {
                            r.Name,
                            Licenses = r
                                .Licenses
                                .Select(l => l.Name)
                        })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"Course name: {course.Name}");
                Console.WriteLine("Resources:");

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"{resource.Name}");
                    Console.WriteLine("Licenses:");
                    Console.WriteLine(string.Join(", ", resource.Licenses));
                }

                Console.WriteLine();
            }
        }

        public static void ListAllStudentsWithCountOfCoursesResourcesAndLicenses(StudentSystemDbContext context)
        {
            context
                .Students
                .Select(s => new
                {
                    s.Name,
                    Courses = s.Courses.Count,
                    Resources = s.Courses.Sum(c => c.Course.Resources.Count),
                    Licenses = s.Courses.Sum(c => c.Course.Resources.Sum(r => r.Licenses.Count))
                })
                .OrderByDescending(s => s.Courses)
                .ThenByDescending(s => s.Resources)
                .ThenBy(s => s.Name)
                .ToList()
                .ForEach(s => Console.WriteLine($"Student name: {s.Name}; Courses count: {s.Courses}" +
                                                Environment.NewLine +
                                                $"Resources count: {s.Resources}; Licenses count: {s.Licenses}" +
                                                Environment.NewLine));
        }
    }
}