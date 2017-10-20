namespace SimpleMvc.App.Views.Home
{
    using SimpleMvc.Framework.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h3>Hello MVC!</h3>";
        }
    }
}