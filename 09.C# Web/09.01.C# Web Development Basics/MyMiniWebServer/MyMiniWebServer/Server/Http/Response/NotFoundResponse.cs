namespace MyMiniWebServer.Server.Http.Response
{
    using MyMiniWebServer.Server.Common;
    using MyMiniWebServer.Server.Enums;
    using MyMiniWebServer.Server.Http.Response;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
