namespace MVCFramework.Core.Interfaces.Generic
{
    public interface IViewResult<T> : IInvocable
    {
        IRenderable<T> Action { get; set; }
    }
}