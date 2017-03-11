using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01.StudentSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime BirthdayDate { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}