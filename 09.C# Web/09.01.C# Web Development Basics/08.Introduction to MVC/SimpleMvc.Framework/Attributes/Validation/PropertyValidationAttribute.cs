namespace SimpleMvc.Framework.Attributes.Validation
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}