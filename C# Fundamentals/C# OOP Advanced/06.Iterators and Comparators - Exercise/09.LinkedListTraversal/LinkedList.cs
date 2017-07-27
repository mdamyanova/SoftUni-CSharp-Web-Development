using System;
using System.Collections;
using System.Collections.Generic;

namespace _09.LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private List<T> collection;

        public LinkedList()
        {
            this.collection = new List<T>();
        }

        public void Add(T item)
        {
            this.collection.Add(item);
        }

        public bool Remove(T item)
        {
            return this.collection.Remove(item);
        }

        public int Count
        {
            get { return this.collection.Count; }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}