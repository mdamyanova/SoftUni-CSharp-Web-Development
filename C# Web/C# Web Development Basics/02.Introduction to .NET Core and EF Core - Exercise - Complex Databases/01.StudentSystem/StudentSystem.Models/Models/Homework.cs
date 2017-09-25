namespace StudentSystem.Models.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using StudentSystem.Models.Enums;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}