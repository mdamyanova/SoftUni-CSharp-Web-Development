namespace SimpleMvc.App
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routes;
    using WebServer;

    public class Launcher
    {   
        public static void Main()
        {
            var server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());

            InitializeDatabase();

            MvcEngine.Run(server);
        }

        private static void InitializeDatabase()
        {
            using (var context = new SimpleMvcDbContext())
            { }
        }
    }
}