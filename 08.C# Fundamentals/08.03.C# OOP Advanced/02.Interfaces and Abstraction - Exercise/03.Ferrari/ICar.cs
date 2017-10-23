namespace _03.Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }
        string Brakes();
        string GasPedal();
    }
}