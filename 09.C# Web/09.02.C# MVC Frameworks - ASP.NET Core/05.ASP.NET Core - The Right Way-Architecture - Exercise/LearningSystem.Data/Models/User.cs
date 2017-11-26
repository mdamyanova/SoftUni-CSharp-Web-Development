namespace LearningSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLenght)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<Article> Articles { get; set; } = new List<Article>();

        public IEnumerable<Course> Trainings { get; set; } = new List<Course>();

        public IEnumerable<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}