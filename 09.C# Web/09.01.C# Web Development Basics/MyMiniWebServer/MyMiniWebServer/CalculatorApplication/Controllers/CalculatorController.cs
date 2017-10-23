namespace MyMiniWebServer.CalculatorApplication.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using ByTheCakeApplication.Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class CalculatorController
    {
        public IHttpResponse Calculate() => this.FileViewResponse("/calculator", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Calculate(string firstNum, string operation, string secondNum)
        {
            // calculator logic 

            var result = "";
            var numOne = double.Parse(firstNum);
            var numTwo = double.Parse(secondNum);

            switch (operation[0])
            {
                case '+':
                    result = (numOne + numTwo).ToString(CultureInfo.InvariantCulture);
                    break;
                case '-':
                    result = (numOne - numTwo).ToString(CultureInfo.InvariantCulture);
                    break;
                case '*':
                    result = (numOne * numTwo).ToString(CultureInfo.InvariantCulture);
                    break;
                case '/':
                    result = (numOne / numTwo).ToString(CultureInfo.InvariantCulture);
                    break;
                default:
                    result = "Invalid Sign";
                    break;
            }

            return this.FileViewResponse(@"/calculator", new Dictionary<string, string>
            {
                ["result"] = result,
                ["showResult"] = "block"
            });
        }

        private const string DefaultPath = @"CalculatorApplication\Resources\{0}.html";

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