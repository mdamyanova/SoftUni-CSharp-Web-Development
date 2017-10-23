using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._05.GenericSwap
{
    public class Box<T>
    {
        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; set; }

        public void Swap(int first, int second)
        {
            var firstElement = this.Data.ElementAt(first);

            this.Data[first] = this.Data.ElementAt(second);
            this.Data[second] = firstElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var value in this.Data)
            {
                sb.AppendLine($"{value.GetType().FullName}: {value}");
            }

            return sb.ToString();
        }
    }
}