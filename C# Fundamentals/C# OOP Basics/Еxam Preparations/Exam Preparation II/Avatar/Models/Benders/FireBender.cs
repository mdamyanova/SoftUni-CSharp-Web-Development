public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double CalculatePower()
    {
        return this.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:f2}";
    }
}