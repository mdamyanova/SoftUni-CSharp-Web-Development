using System;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy.Emoployee
{
    public class Employee : Person, IEmployee
    {
        private decimal salary;

        private string department;

        public Employee(int id, string firstName, string lastName, decimal salary, string department) : 
            base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative");
                }
                this.salary = value;
            }
        }

        public string Department
        {
            get { return this.department; }
            set
            {
                if (value != "Production" && value != "Accounting" && value != "Sales" && value != "Marketing")
                {
                    throw new ArgumentException("Department should be Production, Accounting, Sales or Marketing");
                }
                this.department = value;
            }
        }

        public override string ToString()
        {
            string output =
                $"Employee name: {this.FirstName} {this.LastName}\nId: {this.Id}\nSalary: {this.Salary}\nDepartment: {this.Department}\n";
            return output;
        }
    }
}