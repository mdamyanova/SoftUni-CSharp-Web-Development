namespace Huy_Phuong.CommandManager
{
    internal static class AddTheatre
    {
        public static string ExecuteAddTheatreCommand(string[] theatreName)
        {
            var name = theatreName[0];
            MainProgram.Database.AddTheatre(name);
            return "Theatre added";
        }
    }
}