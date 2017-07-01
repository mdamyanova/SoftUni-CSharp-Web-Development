using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRoster
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var salary = double.Parse(input[1]);
                var position = input[2];
                var department = input[3];

                var employee = new Employee(name, salary, position, department);

                if (input.Length == 6)
                {
                    //input has email and age 
                    var email = input[4];
                    var age = int.Parse(input[5]);

                    employee.Email = email;
                    employee.Age = age; 
                }
                else if (input.Length == 5)
                {
                    //input has either email or age
                    if (input[4].Contains("@"))
                    {
                        var email = input[4];
                        employee.Email = email;
                    }
                    else
                    {
                        var age = int.Parse(input[4]);
                        employee.Age = age;
                    }
                }
               
                employees.Add(employee);
            }

            var result = employees
                .GroupBy(e => e.Department)
                .OrderByDescending(p => p.Average(em => em.Salary))
                .FirstOrDefault()
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {result.Select(r => r.Department).First()} ");
            result.ForEach(em => Console.WriteLine($"{em.Name} {em.Salary:f2} {em.Email} {em.Age}"));
        }
    }
}