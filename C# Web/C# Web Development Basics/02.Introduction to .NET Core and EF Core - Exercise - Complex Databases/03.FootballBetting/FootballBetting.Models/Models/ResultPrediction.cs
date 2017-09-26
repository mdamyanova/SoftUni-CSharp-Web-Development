namespace FootballBetting.Models.Models
{
    using FootballBetting.Models.Enums;

    public class ResultPrediction
    {
        public int Id { get; set; }

        public PredictionType Prediction { get; set; }

        public int BetGameId { get; set; }

        public BetGame BetGame { get; set; }
    }
}