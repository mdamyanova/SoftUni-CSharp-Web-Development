namespace WebServer
{
    using Application;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher :IRunnable
    {
        private Webserver webServer;

        public static void Main()
        {
           new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new MainApplication();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);
           
            this.webServer = new Webserver(8230, appRouteConfig);
            this.webServer.Run();
        }
    }
}