using SoftUni.Data;
using System;
using System.Linq;

namespace SoftUni.Client
{
    public class Startup
    {
        public static void Main()
        {

            var context = new SoftUniEntities();
                //17. Call a stored procedure
                //CallAStoredProcedure(context);

                //18. EmployeesMaximumSalaries(ctx);     
                //EmployeesMaximumSalaries(context);         
        }

        private static void CallAStoredProcedure(SoftUniEntities context)
        {

            context.GetProjectsByName("Ruth", "Ellerbrock");
        }

        private static void EmployeesMaximumSalaries(SoftUniEntities ctx)
        {
            var employees = ctx.Employees.GroupBy(c => c.Department.Name).Select(c => new { DepartmentName = c.Key, MaxSalary = c.Max(b => b.Salary) }).Where(c => c.MaxSalary < 30000 || c.MaxSalary > 70000).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.DepartmentName} - ${emp.MaxSalary:f2}");
            }
        }
    }
}