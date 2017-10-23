namespace FootballBetting.Data
{
    using FootballBetting.Models.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballBettingDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<BetGame> BetGames { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<ResultPrediction> ResultPredictions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=.;Database=FootballBettingDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>()
                .HasOne(p => p.PrimaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Team>()
                .HasOne(p => p.SecondaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Team>()
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId);

            builder.Entity<Town>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);

            builder.Entity<CountriesContinents>()
                .HasKey(cc => new { cc.CountryId, cc.ContinentId });

            builder.Entity<Country>()
                .HasMany(c => c.Continents)
                .WithOne(cc => cc.Country)
                .HasForeignKey(cc => cc.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Continent>()
                .HasMany(c => c.Countries)
                .WithOne(cc => cc.Continent)
                .HasForeignKey(cc => cc.ContinentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(t => t.TeamId);

            builder.Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);

            builder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder.Entity<Player>()
                .HasMany(p => p.PlayerStatistics)
                .WithOne(p => p.Player)
                .HasForeignKey(p => p.PlayerId);

            builder.Entity<Game>()
                .HasMany(g => g.PlayerStatistics)
                .WithOne(g => g.Game)
                .HasForeignKey(p => p.GameId);

            builder.Entity<Game>()
                .HasOne(g => g.Round)
                .WithMany(r => r.Games)
                .HasForeignKey(g => g.RoundId);

            builder.Entity<Game>()
                .HasOne(g => g.Competition)
                .WithMany(c => c.Games)
                .HasForeignKey(c => c.CompetitionId);

            builder.Entity<BetGame>()
                .HasKey(bg => new { bg.BetId, bg.GameId });
            builder.Entity<BetGame>()

                .HasOne(bg => bg.ResultPrediction)
                .WithMany()
                .HasForeignKey(bg => bg.ResultPredictionId);

            builder.Entity<Bet>()
                .HasMany(b => b.Games)
                .WithOne(bg => bg.Bet)
                .HasForeignKey(bg => bg.BetId);

            builder.Entity<Game>()
                .HasMany(g => g.Bets)
                .WithOne(b => b.Game)
                .HasForeignKey(b => b.GameId);

            builder.Entity<ResultPrediction>()
                .HasOne(rp => rp.BetGame)
                .WithOne(b => b.ResultPrediction);

            builder.Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
        }
    }
}