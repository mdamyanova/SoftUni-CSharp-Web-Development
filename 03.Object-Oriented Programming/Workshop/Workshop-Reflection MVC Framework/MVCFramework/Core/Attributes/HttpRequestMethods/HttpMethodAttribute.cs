using System;

namespace MVCFramework.Core.Attributes.HttpRequestMethods
{
    [AttributeUsage(AttributeTargets.All)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}