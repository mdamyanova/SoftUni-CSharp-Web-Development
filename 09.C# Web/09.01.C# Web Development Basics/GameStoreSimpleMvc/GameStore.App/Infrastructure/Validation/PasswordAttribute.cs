namespace GameStore.App.Infrastructure.Validation
{
    using System.Linq;
    using SimpleMvc.Framework.Attributes.Validation;

    public class PasswordAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;

            if (password == null)
            {
                return true;
            }

            return password.Any(char.IsDigit)
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsLower)
                   && password.Length >= 6;
        }
    }
}