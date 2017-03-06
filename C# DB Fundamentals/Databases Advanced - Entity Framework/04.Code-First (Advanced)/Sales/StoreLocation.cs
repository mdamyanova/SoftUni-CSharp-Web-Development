using System.Collections.Generic;

namespace Sales
{
    public class StoreLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Sale> Sales { get; set; }
    }
}