using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02.Photographers.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Albums = new HashSet<Album>();
        }
       
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}