using System.Collections.Generic;

namespace _04.Telephony
{
    public interface ICallable
    {
        ICollection<string> Numbers { get; }
        string Call(string number);
    }
}