namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}