namespace WebServer.Server.Http.Response
{
    using HttpStatusCode = System.Net.HttpStatusCode;

    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = (HttpStatusCode) Enums.HttpStatusCode.NotFound;
        }
    }
}