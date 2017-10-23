namespace MyMiniWebServer.Server.Http.Response
{
    using System;
    using MyMiniWebServer.Server.Http.Response;
    using MyMiniWebServer.Server.Common;
    using MyMiniWebServer.Server.Enums;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
