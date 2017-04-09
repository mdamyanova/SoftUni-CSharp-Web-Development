using PlanetHunters.Models;

namespace PlanetHunters.Data
{
    using System.Data.Entity;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Pioneers)
                .WithMany(a => a.DiscoveriesMade)
                .Map(da =>
                {
                    da.ToTable("PioneersDiscoveriesMade");
                    da.MapLeftKey("DiscoveryMadeId");
                    da.MapRightKey("PioneerId");
                });

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Observers)
                .WithMany(a => a.DiscoveriesObserved)
                .Map(da =>
                {
                    da.ToTable("ObserversDiscoveriesObserved");
                    da.MapLeftKey("DiscoveryObservedId");
                    da.MapRightKey("ObserverId");
                });
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }

        public virtual DbSet<Discovery> Discoveries { get; set; }

        public virtual DbSet<Telescope> Telescopes { get; set; }

        public virtual DbSet<StarSystem> StarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Journal> Journals { get; set; }

        public virtual DbSet<Publication> Publications { get; set; }
    }
}