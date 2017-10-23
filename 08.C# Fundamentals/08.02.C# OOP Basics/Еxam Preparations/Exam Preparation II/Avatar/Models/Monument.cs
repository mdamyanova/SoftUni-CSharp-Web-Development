 public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public abstract int GetBonus();
}