namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using LearningSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Courses;
    using Services;
    using System.Threading.Tasks;

    public class CoursesController : Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;
        
        public CoursesController(ICourseService courses, UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync(id)
            };

            if(model.Course == null)
            {
                return this.NotFound();
            }
          
            if (User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserId(User);
                
                model.UserIsSignedInCourse = await this.courses.StudentIsSignedInCourse(id, userId);
            }
        
            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignInAsync(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var result = await this.courses.SignInStudent(id, userId);

            if (!result)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage("Thank you for your registration.");

            return this.RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOutAsync(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var result = await this.courses.SignOutStudent(id, userId);

            if (!result)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage("Bb!");

            return this.RedirectToAction(nameof(Details), new { id });
        }
    }
}