namespace _08.RawData
{
    public class Tyre
    {
        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; set; }

        public int Age { get; set; }
    }
}