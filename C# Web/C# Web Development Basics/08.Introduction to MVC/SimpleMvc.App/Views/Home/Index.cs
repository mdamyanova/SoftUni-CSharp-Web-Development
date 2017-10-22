namespace SimpleMvc.App.Views.Home
{
    using System.Text;
    using Framework.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<h3>NotesApp</h3>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/register\">Register User</a>");

            return sb.ToString();
        }
    }
}