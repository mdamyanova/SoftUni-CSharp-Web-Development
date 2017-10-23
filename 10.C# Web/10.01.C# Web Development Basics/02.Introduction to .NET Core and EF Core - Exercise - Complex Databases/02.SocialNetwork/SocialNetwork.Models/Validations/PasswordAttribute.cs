namespace SocialNetwork.Models.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        private readonly char[] RequiredSymbols = new char[]
            {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?'};

        public PasswordAttribute()
        {
            this.ErrorMessage = "Password is not valid.";
        }

        public override bool IsValid(object value)
        {
            var password = value as string;

            if (password == null)
            {
                return true;
            }

            return password.All(
                p => char.IsLower(p) 
                || char.IsUpper(p) 
                || char.IsDigit(p)
                || this.RequiredSymbols.Contains(p));
        }
    }
}