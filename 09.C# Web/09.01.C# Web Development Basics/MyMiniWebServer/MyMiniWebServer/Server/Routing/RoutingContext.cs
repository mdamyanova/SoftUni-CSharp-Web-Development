namespace MyMiniWebServer.Server.Routing
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Common;
    using MyMiniWebServer.Server.Handlers;
    using MyMiniWebServer.Server.Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            CoreValidator.ThrowIfNull(handler, nameof(handler));
            CoreValidator.ThrowIfNull(handler, nameof(parameters));

            this.Handler = handler;
            this.Parameters = parameters;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set; }
    }
}
