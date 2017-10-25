namespace GameStore.App.Controllers
{
    using SimpleMvc.Framework.Controllers;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.ViewModel["show-error"] = "none";
        }

        protected void ShowError()
        {
            this.ViewModel["show-error"] = "block";
        }
    }
}