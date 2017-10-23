namespace _01.Human_StudentAndWorker
{
    public class Worker : Human
    {
        private double weekSalary;

        private double workHoursPerDay;

        public double WeekSalary { get; set; }

        public double WorkHoursPerDay { get; set; }
      
        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : 
            base(firstName, lastName)
        {          
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            return (this.WeekSalary / 5) / this.WorkHoursPerDay;
        }
    }
}