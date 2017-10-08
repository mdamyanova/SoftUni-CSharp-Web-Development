namespace MyMiniWebServer.Server.Http.Response
{
    using MyMiniWebServer.Server.Http.Response;
    using MyMiniWebServer.Server.Enums;

    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
