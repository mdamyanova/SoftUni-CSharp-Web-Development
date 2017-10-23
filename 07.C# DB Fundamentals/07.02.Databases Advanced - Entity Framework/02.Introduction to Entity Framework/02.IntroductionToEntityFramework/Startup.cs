using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.IntroductionToEntityFramework
{
    class Startup
    {
        static void Main()
        {
            SoftUniContext softUniDb = new SoftUniContext();

            // 03. Employees full information
            //GetEmployeesFullInformation(softUniDb);

            // 04. Employees with salary over 50 000
            //GetEmployeesWithSalaryOver50000(softUniDb);

            // 05. Employees from Seattle
            //GetEmployeesFromSeattle(softUniDb);

            // 06. Adding a new address and updating employee
            //AddNewAddressAndUpdateEmployee(softUniDb);

            // 07.  Find employees in period
            //FindEmployeesInPeriod(softUniDb);

            // 08. Addresses by town name 
            //GetAddressesByTownName(softUniDb);

            // 09. Manager with id 147
            //GetEmployeeWithId147(softUniDb);

            // 10. Departments with more than 5 employees 
            //GetDepartmentsWithMoreThan5Employees(softUniDb);

            // 11. Find latest 10 projects 
            //GetLatest10Projects(softUniDb);

            // 12. Increase salaries
            //IncreaseSalaries(softUniDb);

            // 13. Find employees by First Name starting with SA
            //FindEmployeesWithFirstNameStartingWithSa(softUniDb);

            //GringottsContext gringottsDb = new GringottsContext();

            // 14. First letter
            //GetFirstLetters(gringottsDb);

            // 15. Delete project by id
            //DeleteProjectWithId(softUniDb);

        }

        private static void GetEmployeesFullInformation(SoftUniContext db)
        {
            var employees = db.Employees.OrderBy(e => e.EmployeeID);
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            }
        }

        private static void GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            Console.WriteLine(String.Join("\n", db.Employees.
                Where(e => e.Salary > 50000).
                Select(e => e.FirstName).
                ToList()));
        }

        private static void GetEmployeesFromSeattle(SoftUniContext db)
        {
            var employees = db.Employees.Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from " +
                                  $"{employee.Department.Name} - ${employee.Salary:f2}");
            }
        }

        private static void AddNewAddressAndUpdateEmployee(SoftUniContext db)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            db.Addresses.Add(address);

            Employee employee = db.Employees.First(e => e.LastName == "Nakov");
            employee.Address = address;

            db.SaveChanges();

            var employeesAddresses =
                db.Employees.OrderByDescending(e => e.AddressID).Select(e => e.Address.AddressText).Take(10);
            foreach (var a in employeesAddresses)
            {
                Console.WriteLine(a);
            }
        }

        private static void FindEmployeesInPeriod(SoftUniContext db)
        {
            var employyes = db.Employees
                .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                .Take(30);
            foreach (var e in employyes)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate} {p.EndDate}");
                }
            }
        }

        private static void GetAddressesByTownName(SoftUniContext db)
        {
            var addresses = db.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).Take(10).ToList();

            foreach (var a in addresses)
            {
                Console.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees");
            }
        }

        private static void GetEmployeeWithId147(SoftUniContext db)
        {
            var employee = db.Employees.First(e => e.EmployeeID == 147);
            var projects = employee.Projects.OrderBy(p => p.Name);

            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
            }
        }

        private static void GetDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var departments = db.Departments.Where(d => d.Employees.Count > 5).OrderBy(d => d.Employees.Count);
            foreach (var  d in departments)
            {
                Console.WriteLine($"{d.Name} {d.Manager.FirstName}");

                foreach (Employee e in d.Employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
                }
            }
        }

        private static void GetLatest10Projects(SoftUniContext db)
        {
            var projects = db.Projects.OrderByDescending(p => p.StartDate).Take(10).OrderBy(p => p.Name);

            foreach (var p in projects)
            {
                Console.WriteLine($"{p.Name} {p.Description} {p.StartDate} {p.EndDate}");
            }
        }

        private static void IncreaseSalaries(SoftUniContext db)
        {
            var employees = db.Employees
               .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                   || e.Department.Name == "Marketing" || e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary = e.Salary + e.Salary * 12 / 100;
            }

            db.SaveChanges();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} " +
                    $"{e.LastName} (${e.Salary:f6})");
            }
        }

        private static void FindEmployeesWithFirstNameStartingWithSa(SoftUniContext db)
        {
            var employees = db.Employees.Where(e => e.FirstName.StartsWith("Sa"));

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f4})");
            }
        }

        private static void GetFirstLetters(GringottsContext db)
        {
            var letters = db.WizzardDeposits.Where(wd => wd.DepositGroup == "Troll Chest")
               .Select(wd => wd.FirstName).ToList().Select(fn => fn[0]).Distinct().OrderBy(c => c);

            foreach (char letter in letters)
            {
                Console.WriteLine(letter);
            }
        }

        private static void DeleteProjectWithId(SoftUniContext db)
        {
            var project = db.Projects.Find(2);

            foreach (var e in project.Employees)
            {
                e.Projects.Remove(project);
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            List<Project> projects = db.Projects.Take(10).ToList();

            foreach (var p in projects)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}