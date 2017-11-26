namespace LearningSystem.Web.Areas.Admin.Controllers
{ 
    using Microsoft.AspNetCore.Mvc;

    public class CoursesController : BaseAdminController
    {
        public IActionResult Create() => this.View();
    }
}