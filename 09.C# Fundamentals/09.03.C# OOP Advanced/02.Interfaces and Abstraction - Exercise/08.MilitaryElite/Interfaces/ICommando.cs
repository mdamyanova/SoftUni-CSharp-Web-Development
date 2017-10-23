using System.Collections.Generic;

namespace _08.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        IList<IMission> Missions { get; }

        void CompleteMission();
    }
}