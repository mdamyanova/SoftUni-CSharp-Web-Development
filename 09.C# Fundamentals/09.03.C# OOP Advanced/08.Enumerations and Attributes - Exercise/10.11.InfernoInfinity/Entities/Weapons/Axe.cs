using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Weapons
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;

        public Axe(string name, string quality)
            : base(name, quality, numberOfSockets: 4)
        {
            base.MinDamage = minDamage;
            base.MaxDamage = maxDamage;
        }
    }
}