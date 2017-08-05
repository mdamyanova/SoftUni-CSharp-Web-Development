using System;
using System.Collections.Generic;

namespace _03.IteratorTest
{
    public class ListIterator
    {
        public ListIterator(params string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.Data = new List<string>(items);
            this.Index = 0;
        }

        public List<string> Data { get; set; }

        public int Index { get; private set; }

        public bool Move()
        {
            if (this.Index >= this.Data.Count - 1)
            {
                return false;
            }

            this.Index++;
            return true;
        }

        public bool HasNext()
        {
            return this.Index != this.Data.Count - 1;
        }

        public string Print()
        {
            if (this.Data.Count == 0 || this.Data == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.Data[this.Index];
        }
    }
}