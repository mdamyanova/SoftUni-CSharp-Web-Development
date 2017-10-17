namespace SimpleMvc.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using ViewEngine.Generic;
    using ViewEngine;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            var controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            var fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            var controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            var fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}