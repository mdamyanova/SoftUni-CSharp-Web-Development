namespace FootballBetting.Client
{
    using FootballBetting.Data;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main()
        {
            var db = new FootballBettingDbContext();
            db.Database.Migrate();
        }
    }
}