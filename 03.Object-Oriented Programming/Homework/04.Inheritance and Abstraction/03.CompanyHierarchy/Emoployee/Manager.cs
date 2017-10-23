using System.Collections.Generic;
using System.Linq;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy.Emoployee
{
    class Manager : Employee, IManager
    {
        public Manager(int id, string firstName, string lastName, decimal salary, string department, List<Employee> employees) :
            base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            string output =
                $"Manager name: {this.FirstName} {this.LastName}\nId: {this.Id}\nSalary: {this.Salary}\nDepartment: {this.Department}\n";
            return this.Employees.Aggregate(output, (current, employee) => current + employee.ToString());
        }
    }
}
