using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        public Stack()
        {
            this.Data = new List<T>();    
        }

        public List<T> Data { get; set; }

        public void Push(T element)
        {
            this.Data.Add(element);
        }

        public T Pop()
        {
            if (this.Data.Count == 0 || this.Data == null)
            {
                throw new InvalidOperationException("No elements");
            }

            var element = this.Data.Last();
            this.Data.Remove(element);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}