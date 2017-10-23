using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        public StringDisperser(params string[] allStrings)
        {
            this.ProcessInputStrings(allStrings);
        }

        public string Text { get; private set; }

        public static bool operator ==(StringDisperser a, StringDisperser b)
        {
            return StringDisperser.Equals(a, b);
        }

        public static bool operator !=(StringDisperser a, StringDisperser b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = (StringDisperser) obj;
            var equals = object.Equals(this.Text, other.Text);

            return equals;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Text.GetHashCode();

            return hashCode;
        }

        public object Clone()
        {
           var clonedDisperser = new StringDisperser(this.Text);
            return clonedDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            var compare = string.Compare(this.Text, other.Text, StringComparison.Ordinal);

            return compare;
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.Text.Length; i++)
            {
               yield return this.Text[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return this.Text;
        }

        private void ProcessInputStrings(string[] inputStrings)
        {
            var result = new StringBuilder();
            foreach (var str in inputStrings)
            {
                result.Append(str);
            }

            this.Text = result.ToString();
        }
    }
}