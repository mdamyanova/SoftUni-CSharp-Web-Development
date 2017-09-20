namespace _02.One_to_ManyRelation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        // 02.One-to-Many Relation
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        // 03.Self-Referenced Table
        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public List<Employee> ManagerEmployees { get; set; }
    }
}