namespace SimpleMvc.App.Views.Users
{
    using System.Text;
    using BindingModels;
    using SimpleMvc.Framework.Interfaces.Generic;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<h2>User: {this.Model.Username}</h2>");
            sb.AppendLine("<form action=\"profile\" method=\"POST\">");
            sb.AppendLine("Title: <input type=\"text\" name=\"Title\" /></br>");
            sb.AppendLine("Content: <input type=\"text\" name=\"Content\" /></br>");
            sb.AppendLine($"<input type=\"hidden\" name=\"UserId\" value=\"{this.Model.UserId}\"/>");
            sb.AppendLine("<input type=\"submit\" value=\"Add Note\" />");
            sb.AppendLine("</form>");
            sb.AppendLine("<h5>List of notes</h5>");
            sb.AppendLine("<ul>");

            foreach (var note in this.Model.Notes)
            {
                sb.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }

            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}