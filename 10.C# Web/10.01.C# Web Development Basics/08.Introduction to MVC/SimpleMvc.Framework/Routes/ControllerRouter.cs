namespace SimpleMvc.Framework.Routes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes.Methods;
    using Controllers;
    using SimpleMvc.Framework.Contracts;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private const int ControllerAndActionUrlLength = 3;

        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = new Dictionary<string, string>(request.UrlParameters);    
            IDictionary<string, string> postParams = new Dictionary<string, string>(request.FormData);

            var requestMethod = request.Method.ToString().ToUpper();

            var controllerName = "";
            var actionName = "";

            //todo
            this.PrepareControllerAndActionNames(request, controllerName, actionName);

            var controller = this.GetController(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();               
            }

            var method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            var methodParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                var response = this.GetResponse(method, controller, methodParams);
                return response;
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
                throw;
            }
        }

        private void PrepareControllerAndActionNames(IHttpRequest request, string controllerName, string actionName)
        {
            // todo: see if this works 

            var url = request.Path;

            if (url.Contains("/"))
            {
                var parts = url.Split("/");

                if (parts.Length == ControllerAndActionUrlLength)
                {
                    // we have valid url 
                    controllerName = parts[1];
                    actionName = parts[2];

                    var controller = controllerName.First().ToString().ToUpper()
                                     + controllerName.Substring(1)
                                     + "Controller";

                    var actionSubstring = actionName.Substring(1);

                    if (actionName.Contains("?"))
                    {
                        actionSubstring =
                            actionName.Substring(1, actionName.IndexOf("?", StringComparison.Ordinal) - 1);
                    }

                    var action = actionName.First().ToString().ToUpper()
                                 + actionSubstring;

                    controllerName = controller;
                    actionName = action;
                }
            }
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            foreach (var methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                var attributes =
                    methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {         
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return 
                controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            var type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }

        private object[] AddParameters(IEnumerable<ParameterInfo> parameters,
            IDictionary<string, string> getParams,
            IDictionary<string, string> postParams)
        {
            var methodParams = new object[parameters.Count()];
            var index = 0;

            foreach (var parameter in parameters)
            {
                if (parameter.ParameterType.IsPrimitive
                    || parameter.ParameterType == typeof(string))
                {
                    methodParams[index] = this.ProcessPrimitiveParameter(parameter, getParams);
                }
                else
                {
                    methodParams[index] = this.ProcessComplexParameter(parameter, postParams);
                    index++;
                }
            }

            return methodParams;
        }

        private object ProcessPrimitiveParameter(ParameterInfo parameter, IDictionary<string, string> getParams)
        {
            var value = getParams[parameter.Name];

            return Convert.ChangeType(value, parameter.ParameterType);
        }

        private object ProcessComplexParameter(ParameterInfo parameter, IDictionary<string, string> postParams)
        {
            var bindingModelType = parameter.ParameterType;
            var bindingModel = Activator.CreateInstance(bindingModelType);
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            var actionResult = method.Invoke(controller, methodParams);

            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                var content = ((IViewable) actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                var redirectUrl = ((IRedirectable) actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }
    }
}