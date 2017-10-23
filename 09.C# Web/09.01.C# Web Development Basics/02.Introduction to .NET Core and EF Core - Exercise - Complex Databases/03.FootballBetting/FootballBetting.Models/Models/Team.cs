namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(3)]
        public string Initials { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public decimal Budget { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}