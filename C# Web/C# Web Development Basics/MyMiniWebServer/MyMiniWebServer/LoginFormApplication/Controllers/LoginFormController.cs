namespace MyMiniWebServer.LoginFormApplication.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ByTheCakeApplication.Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class LoginFormController
    {
        public IHttpResponse Login() => this.FileViewResponse("/login", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Login(string username, string password)
        {
            // login logic

            var result = $"Hi {username}, your password is {password}";

            return this.FileViewResponse(@"/login", new Dictionary<string, string>
            {
                ["result"] = result,
                ["showResult"] = "block"
            });
        }

        private const string DefaultPath = @"LoginFormApplication\Resources\{0}.html";

        public IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            var result = this.ProcessFileHtml(fileName);

            if (values != null && values.Any())
            {
                foreach (var value in values)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            var result = File.ReadAllText(string.Format(DefaultPath, fileName));

            return result;
        }
    }
}