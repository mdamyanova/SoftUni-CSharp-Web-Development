using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _02.Photographers.Enums;

namespace _02.Photographers.Models
{
    public class PhotographerAlbum
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Photographer")]
        public int Photographer_Id { get; set; }

        public virtual Photographer Photographer { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Album")]
        public int Album_Id { get; set; }

        public virtual Album Album { get; set; }

        public Role Role { get; set; }
    }
}