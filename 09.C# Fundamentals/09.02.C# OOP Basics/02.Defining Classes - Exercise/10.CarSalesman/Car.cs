namespace _10.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "n/a";
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Color { get; set; }

        public int Weight { get; set; }
    }
}