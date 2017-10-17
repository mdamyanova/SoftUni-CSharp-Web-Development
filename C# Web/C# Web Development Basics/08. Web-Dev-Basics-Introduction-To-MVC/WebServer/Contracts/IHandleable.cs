namespace WebServer.Contracts
{
    using global::WebServer.Http.Contracts;

    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}