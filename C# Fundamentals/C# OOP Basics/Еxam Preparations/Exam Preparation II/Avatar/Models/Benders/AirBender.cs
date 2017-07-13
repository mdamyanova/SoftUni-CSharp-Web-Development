public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; set; }

    public override double CalculatePower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}