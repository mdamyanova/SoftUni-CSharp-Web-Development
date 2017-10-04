namespace WebServer.Application.Views.Register
{
    using WebServer.Server.Contracts;

    public class RegisterView : IView
    {
        public string View()
        {
            return "<body>" +
                   "     <form method=\"POST\">" +
                   "         Name</br>" +
                   "         <input type=\"text\" name=\"name\" /><br/>" +
                   "         <input type=\"submit\" />" +
                   "     </form>" +
                   "</body>";
        }
    }
}