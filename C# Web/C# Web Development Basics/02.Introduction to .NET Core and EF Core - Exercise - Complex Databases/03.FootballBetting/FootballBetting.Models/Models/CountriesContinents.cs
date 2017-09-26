namespace FootballBetting.Models.Models
{
    public class CountriesContinents
    {
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
    }
}