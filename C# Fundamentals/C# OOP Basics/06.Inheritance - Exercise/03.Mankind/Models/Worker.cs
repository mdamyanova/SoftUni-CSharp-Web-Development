using System;
using System.Text;

namespace _03.Mankind.Models
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workingHours;

        public Worker(string firstName, string lastName, double weekSalary, double workingHours) : base(firstName,
            lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        public override string LastName
        {
            get { return base.LastName; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkingHours
        {
            get { return this.workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        private double GetSalaryPerHour()
        {
            return this.WeekSalary / 5 / this.WorkingHours;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.WorkingHours:f2}");
            sb.AppendLine($"Salary per hour: {this.GetSalaryPerHour():f2}");

            return sb.ToString();
        }
    }
}