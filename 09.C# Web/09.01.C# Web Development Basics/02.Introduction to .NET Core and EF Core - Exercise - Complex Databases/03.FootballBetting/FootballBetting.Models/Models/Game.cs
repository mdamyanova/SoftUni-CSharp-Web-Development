namespace FootballBetting.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime Duration { get; set; }

        public double HomeTeamWinBetRate { get; set; }

        public double AwayTeamWinBetRate { get; set; }

        public double DrawGameBetRate { get; set; }

        public int RoundId { get; set; }

        public Round Round { get; set; }

        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }

        public List<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

        public List<BetGame> Bets { get; set; } = new List<BetGame>();
    }
}