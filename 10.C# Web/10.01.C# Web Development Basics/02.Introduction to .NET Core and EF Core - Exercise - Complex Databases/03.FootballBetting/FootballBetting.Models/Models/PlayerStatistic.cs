namespace FootballBetting.Models.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssist { get; set; }

        public int PlayedMinutesDuringGame { get; set; }
    }
}