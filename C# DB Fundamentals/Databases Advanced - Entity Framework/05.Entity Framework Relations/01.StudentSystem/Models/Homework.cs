using System;
using System.ComponentModel.DataAnnotations;
using StudentSystem.Enums;

namespace _01.StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}