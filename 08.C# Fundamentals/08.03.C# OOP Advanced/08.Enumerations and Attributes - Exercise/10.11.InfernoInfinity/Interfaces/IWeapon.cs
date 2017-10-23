namespace _10._11.InfernoInfinity.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        object Quality { get; }
    }
}