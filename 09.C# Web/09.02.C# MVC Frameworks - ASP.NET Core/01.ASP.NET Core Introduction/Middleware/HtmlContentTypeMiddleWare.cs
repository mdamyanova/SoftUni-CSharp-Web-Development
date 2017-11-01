namespace FluffyDuffyMunchkinCats.Middleware
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class HtmlContentTypeMiddleWare
    {
        private readonly RequestDelegate next;

        public HtmlContentTypeMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HttpHeader.ContentType, "text/html");

            return this.next(context);
        }
    }
}