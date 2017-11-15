namespace CarDealer.Web.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginModel
    {
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}