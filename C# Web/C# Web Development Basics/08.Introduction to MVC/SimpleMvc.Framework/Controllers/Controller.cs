namespace SimpleMvc.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using Helpers;
    using ViewEngine.Generic;
    using ViewEngine;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}