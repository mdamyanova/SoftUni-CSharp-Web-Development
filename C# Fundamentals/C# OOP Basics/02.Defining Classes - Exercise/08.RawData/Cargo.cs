namespace _08.RawData
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }

        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }
}