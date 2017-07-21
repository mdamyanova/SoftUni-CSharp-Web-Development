using System.Collections.Generic;

namespace _08.MilitaryElite.Interfaces
{
    public interface ILeutenantGeneral
    {
        IList<ISoldier> Soldiers { get; }
    }
}