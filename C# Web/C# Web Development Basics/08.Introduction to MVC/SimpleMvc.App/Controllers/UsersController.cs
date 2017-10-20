namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Domain;
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using Framework.Interfaces;
    using Framework.Interfaces.Generic;
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
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames;

            using (this.db)
            {
                usernames = this.db.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel
            {
                Usernames = usernames
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == id);

            var viewModel = new UserProfileViewModel
            {
                UserId = user.Id,
                Username = user.Username,
                Notes = user.Notes.Select(
                    n => new NoteViewModel
                    {
                        Title = n.Title,
                        Content = n.Content
                    })
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
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
    }
}