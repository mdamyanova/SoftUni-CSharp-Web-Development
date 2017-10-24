namespace SimpleMvc.Framework.Controllers
{
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Helpers;
    using ActionResults;
    using Contracts;
    using Models;
    using SimpleMvc.Framework.Attributes.Validation;
    using SimpleMvc.Framework.Security;
    using Views;
    using WebServer.Http;
    using WebServer.Http.Contracts;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model { get; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }

        private void InitializeViewModelData()
        {
            this.Model["displayType"] = this.User.IsAuthenticated ? "block" : "none";
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();
            
            var controllerName = ControllerHelpers.GetControllerName(this);

            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected IActionResult NotFound()
        {
            return new NotFoundResult();
        }

        protected bool IsValidModel(object bindingModel)
        {
            var properties = bindingModel.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is PropertyValidationAttribute)
                    .Cast<PropertyValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!attribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected internal void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }
    }
}