namespace SimpleMvc.App.Views.Users
{
    using Framework.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            return
                "<h3>Register new user</h3>" +
                "<form action=\"register\" method=\"POST\">" +
                "Username:" +
                "<input type=\"text\" name=\"Username\" placeholder=\"Username\"/>" +
                "<br />" +
                "Password:" +
                "<input type=\"password\" name=\"Password\" placeholder=\"Password\"/>" +
                "<br />" +
                "<input type=\"submit\" value=\"Register\" />" +
                "</form>";
        }
    }
}