public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; set; }

    public int Power { get; set; }

    public abstract double CalculatePower();
}