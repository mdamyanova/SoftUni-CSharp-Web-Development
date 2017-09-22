namespace StudentSystem.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public List<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();

        public List<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}