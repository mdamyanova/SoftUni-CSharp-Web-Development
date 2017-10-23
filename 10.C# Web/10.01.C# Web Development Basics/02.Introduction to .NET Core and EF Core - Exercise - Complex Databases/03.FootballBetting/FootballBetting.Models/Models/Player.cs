namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte SquadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public string PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public List<PlayerStatistic> PlayerStatistics { get; set; }
    }
}