namespace WebServer.Server.Http.Contracts
{
    using WebServer.Server.Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }
        
        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }
    }
}