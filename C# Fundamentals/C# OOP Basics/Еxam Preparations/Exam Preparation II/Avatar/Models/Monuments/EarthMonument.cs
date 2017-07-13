public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override int GetBonus()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }
}