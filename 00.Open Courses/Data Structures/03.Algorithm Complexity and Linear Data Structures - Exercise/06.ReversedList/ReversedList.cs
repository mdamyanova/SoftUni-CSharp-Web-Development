namespace _06.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 2;

        private int capacity;
        private T[] elements;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.elements = new T[this.Capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be a positive integer.");
                }

                this.capacity = value;
            }
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                return this.Get(index);
            }
            set
            {
                this.Insert(index, value);
            }
        }

        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                this.Grow();
            }

            this.elements[this.Count] = item;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var reversedIndex = this.ReverseIndex(index);

            // move elements left
            for (int i = reversedIndex; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.Count--;
            this.elements[this.Count] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T Get(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var reversedIndex = this.ReverseIndex(index);

            return this.elements[reversedIndex];
        }

        private T Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var reversedIndex = this.ReverseIndex(index);

            this.elements[reversedIndex] = item;

            return item;
        }

        private int ReverseIndex(int index)
        {
            var reversedIndex = this.Count - index - 1;

            return reversedIndex;
        }

        private void Grow()
        {
            this.Capacity *= 2;
            var newArray = new T[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }
    }
}