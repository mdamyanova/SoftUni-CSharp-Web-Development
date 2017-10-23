using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}