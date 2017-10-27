﻿namespace SimpleMvc.Framework.Helpers
{
    using Framework.Controllers;

    public static class ControllerHelpers
    {
        public static string GetControllerName(Controller controller) =>
            controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        public static string GetViewFullQualifiedName(
            string controller,
            string action)
            => string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controller,
                action);
    }
}