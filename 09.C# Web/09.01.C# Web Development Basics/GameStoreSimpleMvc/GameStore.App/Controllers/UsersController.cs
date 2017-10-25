namespace GameStore.App.Controllers
{
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using Models.Users;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private IUsersService users;

        public UsersController()
        {
            this.users = new UsersService();

            this.ViewModel["show-email-error"] = "none";
            this.ViewModel["show-password-error"] = "none";
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword
                || !this.IsValidModel(model))
            {
                this.ShowError();

                return this.View();
            }

            var result = this.users.Create(model.Email, model.Password, model.Name);

            if (result)
            {
                this.SignIn(model.Email);
                return this.Redirect("/users/login");
            }

            this.ViewModel["show-email-error"] = "block";

            return this.View();
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError();
                return this.View();
            }

            if (this.users.UserExists(model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.Redirect("/");
            }

            this.ViewModel["show-password-error"] = "block";
            return this.View();
        }
    }
}