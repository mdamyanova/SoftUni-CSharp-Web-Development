using System.Collections.Generic;
using System.Linq;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy.Emoployee
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(int id, string firstName, string lastName, decimal salary, string department, List<Sale> sales) : 
            base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales { get; set; }

        public override string ToString()
        {
            string output =
                $"Sales employee name: {this.FirstName} {this.LastName}\nId: {this.Id}\nSalary: {this.Salary}\nDepartment: {this.Department}\n";
            return this.Sales.Aggregate(output, (current, sale) => current + $"Sale: {sale.ToString()}\n");
        }
    }
}