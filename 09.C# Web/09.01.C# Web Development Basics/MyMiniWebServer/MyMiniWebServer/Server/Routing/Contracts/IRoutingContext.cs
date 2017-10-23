namespace MyMiniWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}
