namespace MyMiniWebServer.Server.Http.Response
{
    using MyMiniWebServer.Server.Common;
    using MyMiniWebServer.Server.Enums;
    using MyMiniWebServer.Server.Http;

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
