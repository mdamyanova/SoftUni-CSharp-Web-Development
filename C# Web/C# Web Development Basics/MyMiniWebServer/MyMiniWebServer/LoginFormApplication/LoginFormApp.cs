namespace MyMiniWebServer.LoginFormApplication
{
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class LoginFormApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new LoginFormController().Login());

            appRouteConfig
                .Post(
                    "/",
                    req => new LoginFormController().Login(req.FormData["username"], req.FormData["password"]));
        }
    }
}