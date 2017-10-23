namespace SimpleMvc.Framework.Routes
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var fileFullName = request.Path.Split("/").Last();
            var fileExtension = request.Path.Split(".").Last();

            IHttpResponse fileReponse = null;

            try
            {
                var fileContent = this.ReadFileContent(fileFullName, fileExtension);
                fileReponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception e)
            {
                return new NotFoundResponse();
            }

            return fileReponse;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            var byteContent = File.ReadAllBytes(string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResourcesFolder,
                fileExtension,
                fileFullName));

            return byteContent;
        }
    }
}