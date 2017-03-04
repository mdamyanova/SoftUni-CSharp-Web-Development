using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CreateUser.Models
{
    public class User
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 30 symbols")]
        [Required]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
       // [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z])")]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        
        //[RegularExpression("(?<=\\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\\-?[a-z]+(?:\\.[a-z]+)+)\\b")]
        [Required]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
