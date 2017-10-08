namespace MyMiniWebServer.Server.Http
{
    using MyMiniWebServer.Server.Common;
    using MyMiniWebServer.Server.Http.Contracts;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;
    }
}
