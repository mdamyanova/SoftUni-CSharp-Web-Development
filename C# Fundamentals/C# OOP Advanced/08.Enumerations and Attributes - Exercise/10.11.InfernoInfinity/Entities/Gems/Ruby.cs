using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitality = 5;

        public Ruby(string quality)
            : base(quality)
        {
            base.Strength = strength;
            base.Agility = agility;
            base.Vitality = vitality;
        }
    }
}