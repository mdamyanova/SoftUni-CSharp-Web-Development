namespace MyMiniWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Enums;

    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
    }
}
