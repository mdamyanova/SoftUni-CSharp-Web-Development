namespace Huy_Phuong.CommandManager
{
    using System.Linq;

    public class PrintPerformances
    {
        public static string ExecutePrintPerformancesCommand(string[] theatreInfo)
        {
            var strTheatreInfo = theatreInfo[0];
            var performances = MainProgram.Database.ListPerformances(strTheatreInfo).Select(
                p =>
                    {
                        var performance = p.DateTime.ToString("dd.MM.yyyy HH:mm");
                        return $"({p.PerformanceName}, {performance})";
                    }).ToList();
            return performances.Any() ? string.Join(", ", performances) : "No performances";
        }
    }
}