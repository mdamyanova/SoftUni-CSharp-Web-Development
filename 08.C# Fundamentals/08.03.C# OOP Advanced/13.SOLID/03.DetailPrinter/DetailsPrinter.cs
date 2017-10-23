namespace _03.DetailPrinter
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintEmployees()
        {
            foreach (var employee in this.employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}