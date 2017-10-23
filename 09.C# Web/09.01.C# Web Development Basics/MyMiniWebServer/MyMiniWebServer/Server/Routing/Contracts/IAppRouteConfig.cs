namespace MyMiniWebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Enums;
    using MyMiniWebServer.Server.Handlers;
    using MyMiniWebServer.Server.Http.Contracts;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);
    }
}
