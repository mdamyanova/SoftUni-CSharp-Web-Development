namespace GameStore.App.Infrastructure.Validation
{
    using SimpleMvc.Framework.Attributes.Validation;

    public class EmailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;

            if (email == null)
            {
                return true;
            }

            return email.Contains(".") && email.Contains("@");
        }
    }
}