public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override int GetBonus()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}