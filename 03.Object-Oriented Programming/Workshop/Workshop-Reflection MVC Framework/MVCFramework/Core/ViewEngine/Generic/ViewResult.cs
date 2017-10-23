using System;
using MVCFramework.Core.Interfaces.Generic;

namespace MVCFramework.Core.ViewEngine.Generic
{
    public class ViewResult<T> : IViewResult<T>
    {
        public ViewResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewFullQualifiedName));
            this.Action.Model = model;
        }
        public void Invoke()
        {
           this.Action.Render();
        }

        public IRenderable<T> Action { get; set; }
    }
}