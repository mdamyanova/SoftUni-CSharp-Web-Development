namespace WebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}