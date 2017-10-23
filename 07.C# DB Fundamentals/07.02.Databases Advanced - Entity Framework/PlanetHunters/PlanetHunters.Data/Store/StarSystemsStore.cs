using System.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class StarSystemsStore
    {
        public static void AddStarSystem(StarSystemDto starSystem, PlanetHuntersContext context)
        {
            context.StarSystems.Add(new StarSystem(){Name =  starSystem.Name});
            context.SaveChanges();
        }
        public static StarSystem GetStarSystemByName(string name, PlanetHuntersContext context)
        {
            return context.StarSystems.FirstOrDefault(n => n.Name == name);
        }
    }
}