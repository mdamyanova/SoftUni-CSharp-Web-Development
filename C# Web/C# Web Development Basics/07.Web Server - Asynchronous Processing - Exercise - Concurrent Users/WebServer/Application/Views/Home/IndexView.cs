namespace WebServer.Application.Views.Home
{
    using Server.Contracts;

    public class IndexView : IView
    {
        public string View()
        {
            return "<h1>ZDR</h1>";
        }
    }
}