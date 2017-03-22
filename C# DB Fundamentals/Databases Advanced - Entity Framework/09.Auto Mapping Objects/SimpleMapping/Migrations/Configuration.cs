using SimpleMapping.Models;

namespace SimpleMapping.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeesContext context)
        {
            context.Employees.AddOrUpdate(e => new {e.FirstName, e.LastName},
                new Employee()
                {
                    FirstName = "Petra",
                    LastName = "Samuilova",
                    BirthDay = new DateTime(1966, 10, 4),
                    Salary = 5000.00m,
                    Adress = "Sofia",
                    IsOnVacation = false,
                    Subordinates = new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Dimcho",
                            LastName = "Dimev",
                            BirthDay = new DateTime(1987, 5, 25),
                            Salary = 2000.00m,
                            Adress = "Sofia"
                        },
                        new Employee()
                        {
                            FirstName = "Shanaya",
                            LastName = "Kolev",
                            BirthDay = new DateTime(1979, 11, 27),
                            Salary = 2000.00m,
                            Adress = "Sofia"
                        }
                    }
                },
                new Employee()
                {
                    FirstName = "Metodi",
                    LastName = "Kirilov",
                    BirthDay = new DateTime(1988, 12, 25),
                    Salary = 4000.00m,
                    Adress = "Sofia",
                    Subordinates = new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Sebastian",
                            LastName = "Shtraus",
                            BirthDay = new DateTime(1979, 1, 9),
                            Salary = 2000.00m,
                            Adress = "Sofia",
                            IsOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Mule",
                            LastName = "Mulev",
                            BirthDay = new DateTime(1997, 5, 25),
                            Salary = 2030.00m,
                            Adress = "Sofia",
                            IsOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Stilio",
                            LastName = "Dimitrov",
                            BirthDay = new DateTime(1995, 12, 28),
                            Salary = 2000.21m,
                            Adress = "Sofia"
                        }
                    }
                });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}