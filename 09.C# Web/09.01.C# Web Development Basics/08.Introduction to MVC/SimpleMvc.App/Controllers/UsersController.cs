namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Domain;
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using SimpleMvc.Framework.Contracts;
    using WebServer.Exceptions;

    public class UsersController : Controller
    {
        private SimpleMvcDbContext db = new SimpleMvcDbContext();

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            using (this.db)
            {
                if (this.db.Users.Any(u => u.Username == model.Username))
                {
                    //it's good to show some kind of page here
                    throw new BadRequestException("Username is already in use.");
                }

                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };


                this.db.Users.Add(user);
                this.db.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (this.db)
            {
                var foundUser = this.db.Users.FirstOrDefault(u => u.Username == loginUserBinding.Username);

                if (foundUser == null)
                {
                    return RedirectToAction("/home/login");
                }

                this.db.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            Dictionary<int, string> usersAndIds;

            using (this.db)
            {
                usersAndIds = this.db.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] =
                usersAndIds.Any()
                    ? string.Join(string.Empty, usersAndIds.Select(
                        u => $"<li><a href\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
                    : string.Empty;
            
            return this.View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == id);

            //todo

            //this.Model[""] = ....
            //var viewModel = new UserProfileViewModel
            //{
            //    UserId = user.Id,
            //    Username = user.Username,
            //    Notes = user.Notes.Select(
            //        n => new NoteViewModel
            //        {
            //            Title = n.Title,
            //            Content = n.Content
            //        })
            //}

            return this.View();
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
        {
            var user = this.db.Users.Find(model.UserId);
            var note = new Note
            {
                Title = model.Title,
                Content = model.Content,                
            };

            user.Notes.Add(note);
            this.db.SaveChanges();

            return this.Profile(model.UserId);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction("/home/index");
        }
    }
}