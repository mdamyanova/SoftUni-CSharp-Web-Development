using MVCFramework.BindingModels;
using MVCFramework.Core.Attributes.HttpRequestMethods;
using MVCFramework.Core.Controllers;
using MVCFramework.Core.Interfaces;

namespace MVCFramework.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IViewResult Index(int id, IndexBindingModel model)
        {
            return View();
        }

        [HttpPost]
        public IViewResult Index(int id)
        {
            return View();
        }
    }
}