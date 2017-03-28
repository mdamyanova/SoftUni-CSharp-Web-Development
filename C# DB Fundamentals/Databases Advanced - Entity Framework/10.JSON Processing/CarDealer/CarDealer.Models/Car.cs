using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<Part>();
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public float TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}