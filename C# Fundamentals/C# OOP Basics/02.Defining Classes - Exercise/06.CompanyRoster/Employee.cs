namespace _06.CompanyRoster
{
    public class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, double salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.Age = -1;
        }

        public Employee(string name, double salary, string position, string department, string email, int age) : this(name, salary, position,
            department)
        {
            this.Email = email;
            this.Age = age;
        }

        public Employee(string name, double salary, string position, string department, string email) : this(name, salary, position,
            department)
        {
            this.Email = email;
            this.Age = -1;
        }

        public Employee(string name, double salary, string position, string department, int age) : this(name, salary, position,
            department)
        {
            this.Email = "n/a";
            this.Age = age;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}