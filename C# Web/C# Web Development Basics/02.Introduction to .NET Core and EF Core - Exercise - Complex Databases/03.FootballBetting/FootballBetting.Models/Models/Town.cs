namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
    }
}