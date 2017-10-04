namespace WebServer.Application
{
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using WebServer.Server.Enums;

    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());
            //appRouteConfig.Get("/user/{(?<name>[a-z]+)}", request => new UserController().Details(request.UrlParameters["name"]));
        }
    }
}