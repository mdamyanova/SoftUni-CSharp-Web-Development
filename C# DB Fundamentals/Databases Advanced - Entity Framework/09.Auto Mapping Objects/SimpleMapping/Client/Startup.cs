using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleMapping.Dtos;
using SimpleMapping.Models;

namespace SimpleMapping.Client
{
    public class StartUp
    {
        public static void Main()
        {

            #region Advanced Mapping
            Console.WriteLine("Advanced Mapping");
            List<Employee> managers = SampleEmployeesSeed();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>();
            });


            Mapper.Map<IEnumerable<Employee>,
                IEnumerable<ManagerDto>>(managers)
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();
            #endregion

            #region Projection
            Console.WriteLine("Projection");
            var context = new EmployeesContext();
            context.Database.Initialize(true);
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dto => dto.ManagerLastName, opt => opt.MapFrom(src => src.Manager.LastName)));

            context.Employees.Where(emp => emp.BirthDay.Value.Year < 1990).OrderByDescending(emp => emp.Salary)
                .ProjectTo<EmployeeDto>().ToList().ForEach(emp =>
                {
                    var mln = emp.ManagerLastName ?? "[no manager]";
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Salary} - Manager: {mln}");
                });
            #endregion

        }

        private static List<Employee> SampleEmployeesSeed()
        {
            var managers = new List<Employee>()
            {
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
                }
            };
            return managers;
        }
    }
}