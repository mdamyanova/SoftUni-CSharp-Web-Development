namespace MyMiniWebServer.Server.Contracts
{
    using MyMiniWebServer.Server.Routing.Contracts;

    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}
