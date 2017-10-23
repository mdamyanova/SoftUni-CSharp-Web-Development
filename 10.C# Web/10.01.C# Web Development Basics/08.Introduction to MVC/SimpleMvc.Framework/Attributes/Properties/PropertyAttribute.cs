namespace SimpleMvc.Framework.Attributes.Properties
{
    using System;

    public abstract class PropertyAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}