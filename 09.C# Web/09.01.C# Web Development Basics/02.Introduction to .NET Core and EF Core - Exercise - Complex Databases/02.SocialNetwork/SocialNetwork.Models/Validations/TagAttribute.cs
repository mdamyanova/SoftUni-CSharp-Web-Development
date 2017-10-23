namespace SocialNetwork.Models.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TagAttribute : ValidationAttribute
    {
        public TagAttribute()
        {
            this.ErrorMessage = "Tag is not valid.";
        }

        public override bool IsValid(object value)
        {
            var tag = value as string;

            if (tag == null)
            {
                return true;
            }

            return tag.StartsWith("#") && tag.All(c => !char.IsWhiteSpace(c)) && tag.Length <= 20;
        }
    }
}