namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;

        public CoursesController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            var trainers = await this.userManager
                .GetUsersInRoleAsync(WebConstants.TrainerRole);

            var trainerListItems = trainers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();

            return this.View(new AddCourseFormModel
            {
                Trainers = trainerListItems
            });
        }
    }
}