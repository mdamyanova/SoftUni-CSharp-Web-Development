namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Trainers;
    using Services;
    using Services.Models;
    using System.Threading.Tasks;

    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainersController : Controller
    {
        private readonly ITrainerService trainers;
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public TrainersController(ITrainerService trainers, ICourseService courses, UserManager<User> userManager)
        {
            this.trainers = trainers;
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Courses()
        {
            var userId = this.userManager.GetUserId(User);

            var courses = await this.trainers.CoursesAsync(userId);

            return this.View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return this.NotFound();
            }

            return this.View(new StudentsInCourseViewModel
            {
                Students = await this.trainers.StudentsInCourseAsync(id),
                Course = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return this.BadRequest();
            }

            var success = await this.trainers.AddGrade(id, studentId, grade);

            if (!success)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(Students), new { id });
        }
    }
}