namespace StudentSystem.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq; 
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data;
    using StudentSystem.Models.Enums;
    using StudentSystem.Models.Models;

    public class Startup
    {
        public static Random random = new Random();

        public static void Main()
        {
            var context = new StudentSystemDbContext();

            using (context)
            {
                context.Database.Migrate();
                // SeedInitialData(context);
                // SeedLicenses(context);
                // CrudOperations.ListAllStudentsAndHomeworks(context);
                // CrudOperations.ListAllCoursesAndResources(context);
                // CrudOperations.ListAllCoursesWithMoreThanFiveResources(context);
                // CrudOperations.ListAllCoursesActiveOnGivenDate(context, DateTime.Now);
                // CrudOperations.ListAllStudentsInformation(context);
                // CrudOperations.ListAllCoursesWithResourcesAndLicenses(context);
                CrudOperations.ListAllStudentsWithCountOfCoursesResourcesAndLicenses(context);
            }
        }

        private static void SeedInitialData(StudentSystemDbContext context)
        {            
            const int studentsCount = 25;
            const int coursesCount = 10;
            var currentDate = DateTime.Now;
            
            // add students 
            for (int i = 0; i < studentsCount; i++)
            {
                context.Students.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    Birthday = currentDate.AddYears(-20).AddDays(i),
                    PhoneNumber = $"Random phone {i}"
                });                
            }

            context.SaveChanges();

            // add courses 
            var addedCourses = new List<Course>();
            
            for (int i = 0; i < coursesCount; i++)
            {
                var course = new Course
                {
                    Name = $"Course {i}",
                    Description = $"Course description {i}",
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(20 + i),
                    Price = 100 * i,                  
                };

                addedCourses.Add(course);
                context.Courses.Add(course);
            }

            context.SaveChanges();

            // add students to courses 
            var studentsIds = context.Students.Select(s => s.Id).ToList();

            for (int i = 0; i < coursesCount; i++)
            {
                var currentCourse = addedCourses[i];
                var studentsInCourse = random.Next(2, coursesCount / 2);

                for (int j = 0; j < studentsInCourse; j++)
                {
                    var studentId = studentsIds[random.Next(0, studentsIds.Count)];

                    if (currentCourse.Students.All(s => s.StudentId != studentId))
                    {
                        currentCourse.Students.Add(new StudentsCourses
                        {
                            StudentId = studentId
                        });
                    }
                    else
                    {
                        j--;
                    }                   
                }

                var types = Enum.GetValues(typeof(ResourceType)).Cast<int>().ToArray();
                
                currentCourse.Resources.Add(new Resource
                {
                    Name = $"Resource {i}",
                    Url = $"URL {i}",
                    ResourceType = (ResourceType)types[random.Next(0, types.Length)]
                });
            }

            context.SaveChanges();

            // add homeworks 
            for (int i = 0; i < coursesCount; i++)
            {
                var currentCourse = addedCourses[i];
                var currentStudentsIds = currentCourse
                    .Students
                    .Select(s => s.Student.Id)
                    .ToList();

                for (int j = 0; j < currentStudentsIds.Count; j++)
                {
                    var studentHomeworksCount = random.Next(2, 5);

                    for (int k = 0; k < studentHomeworksCount; k++)
                    {
                        context.Homeworks.Add(new Homework
                        {
                            Content = $"Content homework {i}",
                            SubmissionDate = currentDate.AddDays(-1),
                            ContentType = ContentType.Zip,
                            StudentId = currentStudentsIds[j],
                            CourseId = currentCourse.Id
                        });
                    }
                }

                context.SaveChanges();
            }
        }

        private static void SeedLicenses(StudentSystemDbContext context)
        {
            var resourcesId = context.Resources.Select(r => r.Id).ToList();

            for (int i = 0; i < resourcesId.Count; i++)
            {
                var totalLicenses = random.Next(1, 4);

                for (int j = 0; j < totalLicenses; j++)
                {
                    context.Licenses.Add(new License
                    {
                        Name = $"License {i} {j}",
                        ResourceId = resourcesId[i]
                    });
                }

                context.SaveChanges();
            }
        }
    }
}