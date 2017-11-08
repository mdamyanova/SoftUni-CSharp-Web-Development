namespace CarDealer.Web.Data.Models
{
    using System.Collections.Generic;

    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCars> Cars { get; set; } = new HashSet<PartCars>();

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}