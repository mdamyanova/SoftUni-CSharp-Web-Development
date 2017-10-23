namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;

    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CountriesContinents> Countries { get; set; } = new List<CountriesContinents>();
    }
}