using SimpleMapping.Models;

namespace SimpleMapping
{
    using System.Data.Entity;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
         : base("name=EmployeesContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}