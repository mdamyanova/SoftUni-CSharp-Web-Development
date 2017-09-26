namespace SocialNetwork.Models.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class EmailAttribute : ValidationAttribute
    {
        public EmailAttribute()
        {
            this.ErrorMessage = "Email is not valid.";
        }

        public override bool IsValid(object value)
        {
            var email = value as string;

            if (email == null)
            {
                return true;
            }

            var emailPattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            var regex = new Regex(emailPattern);
            var isMatch = regex.IsMatch(email);

            return isMatch;
        }
    }
}