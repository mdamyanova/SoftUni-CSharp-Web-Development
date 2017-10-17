namespace SimpleMvc.App.Views.Users
{
    using System.Text;
    using BindingModels;
    using SimpleMvc.Framework.Interfaces.Generic;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var username in this.Model.Usernames)
            {
                sb.AppendLine($"<li>{username}</li>");
            }

            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}