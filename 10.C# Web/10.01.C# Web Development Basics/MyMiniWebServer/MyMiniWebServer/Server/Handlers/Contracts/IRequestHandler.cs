namespace MyMiniWebServer.Server.Handlers.Contracts
{
    using MyMiniWebServer.Server.Http.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext context);
    }
}
