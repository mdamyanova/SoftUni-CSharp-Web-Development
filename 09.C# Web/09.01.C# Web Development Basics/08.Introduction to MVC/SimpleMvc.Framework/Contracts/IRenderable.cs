namespace SimpleMvc.Framework.Contracts
{
    using WebServer.Http.Contracts;

    public interface IRenderable
    {
        string Render();
    }
}