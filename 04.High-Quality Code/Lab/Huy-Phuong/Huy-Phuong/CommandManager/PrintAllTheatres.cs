namespace Huy_Phuong.CommandManager
{
    using System.Linq;
    using System.Text;

    public class PrintAllTheatres
    {
        public static string ExecutePrintAllTheatresCommand()
        {
            var theatres  = MainProgram.Database.ListTheatres();
            if (theatres.ToList().Count > 0)
            {
                StringBuilder result = new StringBuilder();
                foreach (var item in theatres.ToList())
                {
                    result.Append(item);
                    result.Append(", ");
                }

                result.Remove(result.Length - 2, 2); //Remove the last comma and space.

                return result.ToString();
            }
            return "No theatres";
        }
    }
}