namespace CarDealer.Web.Services.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Parts { get; set; }

        public bool IsImporter { get; set; }
    }
}