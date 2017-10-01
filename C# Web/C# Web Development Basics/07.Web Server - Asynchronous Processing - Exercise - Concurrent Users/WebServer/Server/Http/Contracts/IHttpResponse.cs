namespace WebServer.Server.Http.Contracts
{
    using System.Net;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }
        
        HttpHeaderCollection Headers { get; }
    }
}