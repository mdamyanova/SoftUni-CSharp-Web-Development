using System.Collections.Generic;
using System.Linq;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy.Emoployee
{
    public class Developer : RegularEmployee, IDeveloper
    {
        public Developer(int id, string firstName, string lastName, int salary, string department, List<Project> projects) :
            base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            string output = $"Developer name: {this.FirstName} {this.LastName}\nId: {this.Id}\nSalary: {this.Salary}\nDepartment: {this.Department}\n";
            return this.Projects.Aggregate(output, (current, project) => current + project.ToString());
        }
    }
}