using _10._11.InfernoInfinity.Entities.Gems;
using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Factories
{
    public class GemFactory
    {
        public Gem Create(string gem)
        {
            Gem newGem = null;
            var gemInfo = gem.Split(' ');
            var quality = gemInfo[0];
            var type = gemInfo[1];

            switch (type.ToLower())
            {
                case "ruby":
                    newGem = new Ruby(quality);
                    break;
                case "emerald":
                    newGem = new Emerald(quality);
                    break;
                case "amethyst":
                    newGem = new Amethyst(quality);
                    break;
            }

            return newGem;
        }
    }
}