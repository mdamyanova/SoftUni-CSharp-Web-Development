namespace CameraBazaar.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
   
    public class ProfileController : Controller
    {
        private readonly IProfileService profile;

        public ProfileController(IProfileService profile)
        {
            this.profile = profile;
        }

        [Authorize]
        public IActionResult Show()
        {
            var model = this.profile.Show();
            return this.View(model);
        }
    }
}