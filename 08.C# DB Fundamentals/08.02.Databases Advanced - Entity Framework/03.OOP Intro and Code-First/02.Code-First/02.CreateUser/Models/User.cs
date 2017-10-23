using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.CreateUser.Models
{
    public class User
    {
        private string password;
        private string email; 

        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                var containsDigit = false;
                var containsLower = false;
                var containsUpper = false;
                var containsSymbol = false;
                foreach (char c in value)
                {
                    if (char.IsDigit(c))
                    {
                        containsDigit = true;
                    }
                    else if (char.IsLower(c))
                    {
                        containsLower = true;
                    }
                    else if (char.IsUpper(c))
                    {
                        containsUpper = true;
                    }
                    else if ("(!@#$%^&*()_+<>?".Contains(c))
                    {
                        containsSymbol = true;
                    }
                }

                if (containsDigit && containsLower && containsUpper && containsSymbol)
                {
                    this.password = value;
                }
                else
                {
                    throw new Exception("Invalid password!");
                }
            }
        }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9]+(-|\.|_)?)*[a-zA-Z0-9]+@[\w]+\.[\w]+$");
                if (!regex.IsMatch(value))
                {
                    throw new Exception("Invalid email!");
                }
                this.email = value;
            }
        }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}