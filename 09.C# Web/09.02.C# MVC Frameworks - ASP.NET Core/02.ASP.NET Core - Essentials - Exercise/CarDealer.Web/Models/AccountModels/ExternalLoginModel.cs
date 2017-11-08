namespace CarDealer.Web.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}