namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [StringLength(2)]
        public string Id { get; set; }

        public string Description { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}