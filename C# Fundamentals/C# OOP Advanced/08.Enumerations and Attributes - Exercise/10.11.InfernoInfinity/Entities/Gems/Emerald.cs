using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Entities.Gems
{
    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitality = 9;

        public Emerald(string quality)
            : base(quality)
        {
            base.Strength = strength;
            base.Agility = agility;
            base.Vitality = vitality;
        }
    }
}