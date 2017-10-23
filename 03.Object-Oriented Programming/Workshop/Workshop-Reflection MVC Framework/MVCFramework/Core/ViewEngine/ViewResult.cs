using System;
using MVCFramework.Core.Interfaces;

namespace MVCFramework.Core.ViewEngine
{
    public class ViewResult : IViewResult
    {
        public ViewResult(string viewFullQualifiedName)
        {
            this.Action = (IRenderable) Activator.CreateInstance(Type.GetType(viewFullQualifiedName));
        }

        public void Invoke()
        {
            this.Action.Render();
        }

        public IRenderable Action { get; set; }
    }
}