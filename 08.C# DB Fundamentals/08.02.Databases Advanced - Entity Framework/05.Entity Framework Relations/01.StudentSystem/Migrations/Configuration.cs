using StudentSystem.Enums;
using _01.StudentSystem.Models;

namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentSystem.StudentSystemContext context)
        {
            var students = new Student[]
            {
                new Student()
                {
                    Name = "Todor",
                    RegistrationDate = new DateTime(2017, 3, 1),
                    BirthdayDate = new DateTime(1990, 8, 10)
                },
                new Student()
                {
                    Name = "Sebastian",
                    RegistrationDate = new DateTime(2017, 3, 1),
                    BirthdayDate = new DateTime(1994, 3, 7)
                },
                new Student()
                {
                    Name = "Emanuil",
                    RegistrationDate = new DateTime(2017, 3, 1),
                    BirthdayDate = new DateTime(1988, 6, 23)
                },
                new Student()
                {
                    Name = "Penelope",
                    RegistrationDate = new DateTime(2017, 3, 1),
                    BirthdayDate = new DateTime(1999, 4, 4)
                },
                new Student()
                {
                    Name = "Mariancho",
                    RegistrationDate = new DateTime(2017, 3, 1),
                    BirthdayDate = new DateTime(1992, 2, 2)
                },
            };
            var resources = new Resource[]
            {
                new Resource()
                {
                    Name = "Resource 1",
                    ResourceType = ResourceType.Document,
                    Url = "www.alabala.com"
                },
                 new Resource()
                {
                    Name = "Resource 2",
                    ResourceType = ResourceType.Document,
                    Url = "www.alabala.com"
                }, new Resource()
                {
                    Name = "Resource 3",
                    ResourceType = ResourceType.Presentation,
                    Url = "www.alabala.com"
                },
                  new Resource()
                {
                    Name = "Resource 4",
                    ResourceType = ResourceType.Video,
                    Url = "www.alabala.com"
                },
                   new Resource()
                {
                    Name = "Resource 5",
                    ResourceType = ResourceType.Other,
                    Url = "www.alabala.com"
                },
            };
            var homeworks = new Homework[]
            {
                new Homework()
                {
                    Content = "Homework 1",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2017, 3, 8),
                    Student = students[0]
                },
                new Homework()
                {
                    Content = "Homework 2",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2017, 3, 8),
                    Student = students[1]
                },
                new Homework()
                {
                    Content = "Homework 3",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2017, 3, 8),
                    Student = students[2]
                },
                new Homework()
                {
                    Content = "Homework 4",
                    ContentType = ContentType.Zip,
                    SubmissionDate = new DateTime(2017, 3, 8),
                    Student = students[3]
                },
                new Homework()
                {
                    Content = "Homework 5",
                    ContentType = ContentType.Zip,
                    SubmissionDate = new DateTime(2017, 3, 8),
                    Student = students[4]
                }
            };

            var courses = new Course[]
            {
                new Course()
                {
                    Name = "ASP.NET",
                    Description = "ASP.NET Course for advanced students",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 4, 1),
                    Price = 190.00m,
                    Students = {students[0], students[1], students[2], students[3], students[4]},
                    HomeworkSubmissions = {homeworks[0], homeworks[1], homeworks[2]},
                    Resources = {resources[0], resources[1], resources[2], resources[3], resources[4]}
                }
            };
            context.Students.AddOrUpdate(s => s.Name, students[0]);
            context.Students.AddOrUpdate(s => s.Name, students[1]);
            context.Students.AddOrUpdate(s => s.Name, students[2]);
            context.Students.AddOrUpdate(s => s.Name, students[3]);
            context.Students.AddOrUpdate(s => s.Name, students[4]);

            context.Resources.AddOrUpdate(r => r.Name, resources[0]);
            context.Resources.AddOrUpdate(r => r.Name, resources[1]);
            context.Resources.AddOrUpdate(r => r.Name, resources[2]);
            context.Resources.AddOrUpdate(r => r.Name, resources[3]);
            context.Resources.AddOrUpdate(r => r.Name, resources[4]);

            context.Homeworks.AddOrUpdate(h => h.Content, homeworks[0]);
            context.Homeworks.AddOrUpdate(h => h.Content, homeworks[1]);
            context.Homeworks.AddOrUpdate(h => h.Content, homeworks[2]);
            context.Homeworks.AddOrUpdate(h => h.Content, homeworks[3]);
            context.Homeworks.AddOrUpdate(h => h.Content, homeworks[4]);

            context.Courses.AddOrUpdate(c => c.Name, courses[0]);
        }
    }
}