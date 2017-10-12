namespace MyMiniWebServer
{
    using Application;
    using MyMiniWebServer.ByTheCakeApplication;
    using MyMiniWebServer.CalculatorApplication;
    using MyMiniWebServer.LoginFormApplication;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            // choose the main application 

            //var mainApplication = new MainApplication();
            var mainApplication = new ByTheCakeApp();
            mainApplication.InitializeDatabase();
            // var mainApplication = new CalculatorApp();
            // var mainApplication = new LoginFormApp();

            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}