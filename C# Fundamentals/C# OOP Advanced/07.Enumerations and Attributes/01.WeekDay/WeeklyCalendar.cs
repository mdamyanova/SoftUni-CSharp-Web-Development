using System.Collections.Generic;

public class WeeklyCalendar
{
    private IList<WeeklyEntry> weekData;

    public WeeklyCalendar()
    {
        this.weekData = new List<WeeklyEntry>();
    }

    public void AddEntry(string weekday, string notes)
    {
        this.weekData.Add(new WeeklyEntry(weekday, notes));
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule => this.weekData;
}