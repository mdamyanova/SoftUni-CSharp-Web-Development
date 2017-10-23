public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override int GetBonus()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        return $"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}";
    }
}