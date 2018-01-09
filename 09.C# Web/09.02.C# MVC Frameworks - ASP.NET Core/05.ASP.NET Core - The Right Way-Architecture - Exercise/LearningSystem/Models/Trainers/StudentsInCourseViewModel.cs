namespace LearningSystem.Web.Models.Trainers
{
    using Services.Models;
    using System.Collections.Generic;

    public class StudentsInCourseViewModel
    {
        public IEnumerable<StudentInCourseServiceModel> Students { get; set; }

        public CourseListingServiceModel Course { get; set; }
    }
}