namespace CarDealer.Domain
{
    using System.Collections.Generic;

    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartCars> Parts { get; set; } = new HashSet<PartCars>();
    }
}