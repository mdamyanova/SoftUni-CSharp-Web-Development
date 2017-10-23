using System.Runtime.CompilerServices;
using MVCFramework.Core.Interfaces;
using MVCFramework.Core.Interfaces.Generic;
using MVCFramework.Core.ViewEngine;
using MVCFramework.Core.ViewEngine.Generic;

namespace MVCFramework.Core.Controllers
{
    public class Controller
    {
        protected IViewResult View([CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string fullQualifiedName = 
                MvcContext.Current.AssemblyName
                + "."
                + MvcContext.Current.ViewsFolder
                + "."
                + controllerName
                + "."
                + callee;
           return new ViewResult(fullQualifiedName);

        }

        protected IViewResult View(string controller, string action)
        {
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string fullQualifiedName = 
                MvcContext.Current.AssemblyName 
                + "." 
                +  MvcContext.Current.ViewsFolder 
                + "." 
                +  controller 
                + "." 
                + action;

            return new ViewResult(fullQualifiedName);
        }

        protected IViewResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string fullQualifiedName =
                MvcContext.Current.AssemblyName
                + "."
                + MvcContext.Current.ViewsFolder
                + "."
                + controllerName
                + "."
                + callee;
            return new ViewResult<T>(fullQualifiedName, model);
        }

        protected IViewResult<T> View<T>(T model, string controller, string action)
        {   
            string fullQualifiedName =
                MvcContext.Current.AssemblyName
                + "."
                + MvcContext.Current.ViewsFolder
                + "."
                + controller
                + "."
                + action;
            return new ViewResult<T>(fullQualifiedName, model);
        }
    }
}