namespace WebServer.Server.Http.Response
{
    using WebServer.Server.Common;
    using WebServer.Server.Enums;
    using WebServer.Server.Http;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;

            this.Headers.Add(HttpHeader.Location, redirectUrl);
        }
    }
}
