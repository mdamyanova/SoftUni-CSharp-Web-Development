namespace PlanetHunters.Data
{
    public class Utility
    {
        public static void InitDB()
        {
            var context = new PlanetHuntersContext();
            context.Database.Initialize(true);
        }
    }
}