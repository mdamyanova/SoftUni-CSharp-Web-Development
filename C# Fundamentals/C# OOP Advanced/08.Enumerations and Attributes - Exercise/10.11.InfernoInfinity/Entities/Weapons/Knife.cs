using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Weapons
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;

        public Knife(string name, string quality)
            : base(name, quality, numberOfSockets: 2)
        {
            base.MinDamage = minDamage;
            base.MaxDamage = maxDamage;
        }
    }
}