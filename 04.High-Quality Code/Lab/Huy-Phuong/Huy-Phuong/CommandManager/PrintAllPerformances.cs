namespace Huy_Phuong.CommandManager
{
    using System.Linq;
    using System.Text;

    public class PrintAllPerformances
    {
        public static string ExecutePrintAllPerformancesCommand()
        {
            var performances = MainProgram.Database.ListAllPerformances().ToList();

            if (performances.Any())
            {
                StringBuilder result = new StringBuilder();
                foreach (var performance in performances)
                {
                    result.AppendFormat(
                        "({0}, {1}, {2})",
                        performance.PerformanceName,
                        performance.TheatreName,
                        performance.DateTime.ToString("dd.MM.yyyy HH:mm"));
                    result.Append(", ");
                }

                result.Remove(result.Length - 2, 2); //Remove the last comma and space.

                return result.ToString();
            }       
                return "No performances";
        }
    }
}