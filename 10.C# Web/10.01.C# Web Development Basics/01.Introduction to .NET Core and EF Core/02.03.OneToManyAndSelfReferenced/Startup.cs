namespace _02.One_to_ManyRelation
{
    public class Startup
    {
        public static void Main()
        {
            var context = new DepartmentsDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}