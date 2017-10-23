using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Gems
{
    public class Amethyst : Gem
    {
        private const int strength = 2;
        private const int agility = 8;
        private const int vitality = 4;

        public Amethyst(string quality)
            : base(quality)
        {
            base.Strength = strength;
            base.Agility = agility;
            base.Vitality = vitality;
        }
    }
}