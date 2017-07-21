using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone(ICollection<string> numbers, ICollection<string> urls)
        {
            this.Numbers = new List<string>(numbers);
            this.Urls = new List<string>(urls);
        }

        public ICollection<string> Urls { get; }

        public ICollection<string> Numbers { get; }

        public string Browse(string url)
        {
            return url.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return !number.All(char.IsDigit) ? "Invalid number!" : $"Calling... {number}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var num in this.Numbers)
            {
                sb.AppendLine(Call(num));
            }

            foreach (var url in this.Urls)
            {
                sb.AppendLine(Browse(url));
            }

            return sb.ToString();
        }
    }
}