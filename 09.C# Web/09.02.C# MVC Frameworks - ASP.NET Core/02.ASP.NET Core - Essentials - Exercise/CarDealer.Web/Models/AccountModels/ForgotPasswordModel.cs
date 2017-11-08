namespace CarDealer.Web.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}