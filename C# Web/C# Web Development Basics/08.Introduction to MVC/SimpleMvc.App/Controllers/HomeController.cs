namespace SimpleMvc.App.Controllers
{
    using Framework.Controllers;
    using Framework.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}