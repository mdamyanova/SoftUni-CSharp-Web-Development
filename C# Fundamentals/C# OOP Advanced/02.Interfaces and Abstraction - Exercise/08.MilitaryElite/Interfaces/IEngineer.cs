using System.Collections.Generic;

namespace _08.MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        IList<IRepair> Parts { get; }
    }
}