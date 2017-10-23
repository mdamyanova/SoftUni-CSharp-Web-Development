using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Weapons
{
    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;

        public Sword(string name, string quality)
            : base(name, quality, numberOfSockets: 3)
        {
            base.MinDamage = minDamage;
            base.MaxDamage = maxDamage;
        }
    }
}