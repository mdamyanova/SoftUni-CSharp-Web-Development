using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVCFramework.Core.Attributes.HttpRequestMethods;
using MVCFramework.Core.Controllers;
using MVCFramework.Core.Interfaces;

namespace MVCFramework.Core
{
    public class StartUp
    {
        static void Main()
        {
            RegisterAssemblyName();
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            while (true)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string requestMethod = tokens[0];

                string[] controllerActionParams = tokens[1].Split('/');
                string controllerName = controllerActionParams[0];
                controllerName = (controllerName[0] + "").ToUpper() +
                                 controllerName.Substring(1, controllerName.Length - 1);
                string[] actionAndParams = controllerActionParams[1].Split('?');
                string methodName = actionAndParams[0];
                methodName = (methodName[0] + "").ToUpper() +
                                 methodName.Substring(1, methodName.Length - 1);

                Dictionary<string, object> getParams = new Dictionary<string, object>();
                Dictionary<string, object> postParams = new Dictionary<string, object>();

                if (actionAndParams.Length >= 2)
                {
                    string[] pairs = actionAndParams[1].Split('&');
                    foreach (var pair in pairs)
                    {
                        string[] keyValue = pair.Split('=');
                        getParams.Add(keyValue[0], keyValue[1]);
                    }
                }

                if (tokens.Length >= 3)
                {
                    string[] pairs = tokens[2].Split('&');
                    foreach (var pair in pairs)
                    {
                        string[] keyValue = pair.Split('=');
                        postParams.Add(keyValue[0], keyValue[1]);
                    }
                }

                Controller controller = (Controller) Activator.CreateInstance(Type.GetType(
                    MvcContext.Current.AssemblyName
                    + "."
                    + MvcContext.Current.ControllersFolder
                    + "."
                    + controllerName + MvcContext.Current.ControllerSuffix
                    ));

                IEnumerable<MethodInfo> methods = 
                    controller
                    .GetType()
                    .GetMethods()
                    .Where(m => m.Name == methodName);

                MethodInfo method = null;
                foreach (MethodInfo methodInfo in methods)
                {
                    IEnumerable<Attribute> attributes =
                        methodInfo
                        .GetCustomAttributes()
                        .Where(a => a is HttpMethodAttribute);

                    if (!attributes.Any())
                    {
                        method = methodInfo;
                        break;
                    }

                    foreach (HttpMethodAttribute attribute in attributes)
                    {
                        if (attribute.IsValid(requestMethod))
                        {
                            method = methodInfo;
                            break;
                        }
                    }
                }

                if (method == null)
                {
                    throw new NotSupportedException("No such method");
                }

                IEnumerable<ParameterInfo> parameters = method.GetParameters();

                object[] arguments = new object[parameters.Count()];
                int index = 0;

                foreach (ParameterInfo param in parameters)
                {
                    if (param.ParameterType.IsPrimitive)
                    {
                        object value = getParams[param.Name];
                        arguments[index] = Convert.ChangeType(
                            value,
                            param.ParameterType,
                            null);
                        index++;
                    }
                    else
                    {
                        Type bindingModelType = param.ParameterType;
                        object bindingModel =
                            Activator.CreateInstance(bindingModelType);
                        IEnumerable<PropertyInfo> properties = 
                            bindingModelType.GetProperties();

                        foreach (PropertyInfo property in properties)
                        {
                            property.SetValue(bindingModel, 
                                Convert.ChangeType(
                                    postParams[property.Name], 
                                    property.PropertyType));
                        }

                        arguments[index] = Convert.ChangeType(
                            bindingModel,
                            bindingModelType,
                            null);
                        index++;
                    }
                }

               IInvocable result = (IInvocable)method.Invoke(controller, arguments);
               result.Invoke();
            }
        }
   
        static void RegisterAssemblyName()
        {
            MvcContext.Current.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }

        static void RegisterControllers(string controllersFolder = "Controllers", 
            string controllerSuffix = "Controller" )
        {
            MvcContext.Current.ControllersFolder = controllersFolder;
            MvcContext.Current.ControllerSuffix = controllerSuffix;
        }

        static void RegisterViews(string viewsFolder = "Views")
        {
            MvcContext.Current.ViewsFolder = viewsFolder;
        }

        static void RegisterModels(string modelsFolder = "Models")
        {
            MvcContext.Current.ModelsFolder = modelsFolder;
        }
    }
}