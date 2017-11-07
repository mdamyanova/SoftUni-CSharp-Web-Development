namespace CarDealer.Domain
{
    public class PartCars
    {
        public int PartId { get; set; }

        public Part Part { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}