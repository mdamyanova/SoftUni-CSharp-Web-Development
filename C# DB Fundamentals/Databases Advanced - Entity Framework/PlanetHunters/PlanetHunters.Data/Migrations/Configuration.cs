using PlanetHunters.Models;

namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlanetHunters.Data.PlanetHuntersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlanetHunters.Data.PlanetHuntersContext";
        }

        protected override void Seed(PlanetHunters.Data.PlanetHuntersContext context)
        {
            if (!context.Journals.Any())
            {
                context.Journals.Add(new Journal() { Name = "Journal 1" });
                context.Journals.Add(new Journal() { Name = "Journal 2" });
            }

            var discoveries = context.Discoveries;
            foreach (var contextDiscovery in discoveries)
            {
                contextDiscovery.Publication = new Publication() {ReleaseDate = contextDiscovery.DateMade};
            }
        }
    }
}