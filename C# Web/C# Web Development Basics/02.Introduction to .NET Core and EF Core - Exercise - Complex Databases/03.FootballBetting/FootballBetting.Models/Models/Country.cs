namespace FootballBetting.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Key]
        [StringLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Town> Towns { get; set; } = new List<Town>();

        public List<CountriesContinents> Continents { get; set; } = new List<CountriesContinents>();
    }
}