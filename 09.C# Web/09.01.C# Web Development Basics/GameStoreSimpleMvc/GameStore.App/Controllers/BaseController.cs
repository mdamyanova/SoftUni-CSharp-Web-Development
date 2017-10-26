namespace GameStore.App.Controllers
{
    using System.Linq;
    using Data;
    using Data.Models;
    using SimpleMvc.Framework.Controllers;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.ViewModel["anonymousDisplay"] = "flex";
            this.ViewModel["adminDisplay"] = "none";
            this.ViewModel["userDisplay"] = "none";
            this.ViewModel["show-error"] = "none";
        }

        protected User Profile { get; set; }

        protected void ShowError(string error)
        {
            this.ViewModel["show-error"] = "flex";
            this.ViewModel["error"] = error;
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["anonymousDisplay"] = "none";
                this.ViewModel["userDisplay"] = "flex";

                using (var db = new GameStoreDbContext())
                {
                    this.Profile = db.Users.First(u => u.Email == this.User.Name);

                    if (this.Profile.IsAdmin)
                    {                      
                        this.ViewModel["userDisplay"] = "none";
                        this.ViewModel["adminDisplay"] = "flex";
                    }
                }
            }
        }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;
    }
}