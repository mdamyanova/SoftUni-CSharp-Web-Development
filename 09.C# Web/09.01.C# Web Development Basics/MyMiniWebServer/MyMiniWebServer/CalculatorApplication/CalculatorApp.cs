namespace MyMiniWebServer.CalculatorApplication
{
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class CalculatorApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new CalculatorController().Calculate());

            appRouteConfig
                .Post(
                    "/",
                    req => new CalculatorController().Calculate(req.FormData["firstNum"], req.FormData["operation"], req.FormData["secondNum"]));
        }
    }
}