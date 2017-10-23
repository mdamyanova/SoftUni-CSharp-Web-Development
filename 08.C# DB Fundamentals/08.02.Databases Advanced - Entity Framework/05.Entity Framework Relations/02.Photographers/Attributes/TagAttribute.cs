using System.ComponentModel.DataAnnotations;

namespace _02.Photographers.Attributes
{
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object tag)
        {
            string tagValue = (string)tag;

            if (!tagValue.StartsWith("#"))
            {
                return false;
            }
            if (tagValue.Contains(" ") || tagValue.Contains("\t"))
            {
                return false;
            }
            if (tagValue.Length > 20)
            {
                return false;
            }
            return true;
        }
    }
}