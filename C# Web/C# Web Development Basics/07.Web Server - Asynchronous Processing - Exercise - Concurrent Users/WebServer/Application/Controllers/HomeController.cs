namespace WebServer.Application.Controllers
{
    using System.Net;
    using Application.Views.Home;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class HomeController
    {
        // GET /
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new IndexView());
        }
    }
}