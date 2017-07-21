using System.Collections.Generic;

namespace _04.Telephony
{
    public interface IBrowseable
    {
        ICollection<string> Urls { get; }
        string Browse(string url);
    }
}