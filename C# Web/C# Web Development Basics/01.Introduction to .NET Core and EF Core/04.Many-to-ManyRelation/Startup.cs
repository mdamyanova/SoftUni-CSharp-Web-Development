namespace _04.Many_to_ManyRelation
{
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main()
        {
            var context = new UniversityDbContext();
            ClearDatabase(context);
        }

        private static void ClearDatabase(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}