namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Data;
    using SimpleMvc.Domain;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Framework.Interfaces.Generic;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password
            };

            using (var db = new SimpleMvcDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames = null;

            using (var db = new SimpleMvcDbContext())
            {
                usernames = db.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel
            {
                Usernames = usernames
            };

            return this.View(viewModel);
        }
    }
}