namespace BankSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BankSystem.Models.BankAccounts;

    public class User
    {
        public User()
        {
            
        }

        public User(string username, string password, string email, bool isLogged)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.IsLogged = isLogged;
            this.SavingAccounts = new List<SavingsAccount>();
            this.CheckingAccounts = new List<CheckingAccount>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsLogged { get; set; }

        public List<SavingsAccount> SavingAccounts { get; set; }

        public List<CheckingAccount> CheckingAccounts { get; set; }
    }
}