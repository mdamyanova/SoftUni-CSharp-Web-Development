namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    using Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddCourseFormModel : IValidatableObject
    {
        [Required]
        [MaxLength(DataConstants.CourseNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLenght)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name="Trainer")]
        [Required]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date should be in the future.");
            }

            if(this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("Start date should be before end date.");
            }
        }
    }
}