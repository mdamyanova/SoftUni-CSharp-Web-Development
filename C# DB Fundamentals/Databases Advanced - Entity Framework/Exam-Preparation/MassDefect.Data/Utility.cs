namespace MassDefect.Data
{
    public static class Utility
    {
        public static void InitDB()
        {
            var context = new MassDefectContext();
            context.Database.Initialize(true);
        }
    }
}