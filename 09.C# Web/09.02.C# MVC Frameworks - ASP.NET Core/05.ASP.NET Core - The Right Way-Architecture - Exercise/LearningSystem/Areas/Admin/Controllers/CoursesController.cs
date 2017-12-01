namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using Services.Admin.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService courses;

        public CoursesController(UserManager<User> userManager, IAdminCourseService courses)
        {
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task<IActionResult> Create()
        {          
            return this.View(new AddCourseFormModel
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                Trainers = await this.GetTrainers()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainers();
                return this.View(model);
            }

            await this.courses.Create(model.Name, model.Description, model.StartDate, model.EndDate, model.TrainerId);

            this.TempData.AddSuccessMessage($"Course {model.Name} created successfully!");

            // get out from the area 
            return this.RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
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

            return trainerListItems;
        }
    }
}