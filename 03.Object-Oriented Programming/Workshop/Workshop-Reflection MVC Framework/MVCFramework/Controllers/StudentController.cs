using MVCFramework.BindingModels;
using MVCFramework.Core.Attributes.HttpRequestMethods;
using MVCFramework.Core.Controllers;
using MVCFramework.Core.Interfaces.Generic;
using MVCFramework.ViewModels;

namespace MVCFramework.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IViewResult<StudentViewModel> Edit(int id, StudentBindingModel bindingModel)
        {
            StudentViewModel viewModel = new StudentViewModel();
            viewModel.FullName = bindingModel.FirstName + " " + bindingModel.LastName;

            return View(viewModel);
        }
    }
}