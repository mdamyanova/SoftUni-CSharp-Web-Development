namespace _06.Implement_the_Data_Structure_ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IReversedList<T>
    {
        private const int DefaultCapacity = 16;

        private int capacity;

        private T[] storage;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.storage = new T[this.Capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count { get; private set; }

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
                    throw new ArgumentException(nameof(value), "Capacity must be positive integer");
                }
                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.GetAtIndex(index);
            }
            set
            {
                this.SetAtIndex(index, value);
            }
        }

        public void Add(T item)
        {
            this.Resize();

            this.storage[this.Count] = item;
            this.Count++;
        }

        public void Remove(int index)
        {
            this.CheckIndexIsInRange(index);

            index = this.ReverseIndex(index);

            for (int i = 0; i < this.Count - 1; i++)
            {
                this.storage[i] = this.storage[i + 1];
            }

            this.storage[this.Count - 1] = default(T);
            this.Count--;
        }

        public override string ToString()
        {
            var result = string.Format($"{string.Join(", ", this)}");

            return result;
        }

        private void Resize()
        {
            this.Capacity *= 2;
            var newStorage = new T[this.Capacity];
            Array.Copy(this.storage, newStorage, this.storage.Length - 1);
            this.storage = newStorage;
        }

        private int ReverseIndex(int index)
        {
            var reversedIndex = this.Count - 1 - index;

            return reversedIndex;
        }

        private T GetAtIndex(int index)
        {
            this.CheckIndexIsInRange(index);

            index = this.ReverseIndex(index);

            var element = this.storage[index];

            return element;
        }

        private void SetAtIndex(int index, T element)
        {
            this.CheckIndexIsInRange(index);

            this.ResizeIfNeeded();

            index = this.ReverseIndex(index) + 1;

            for (int i = this.Count; i >= index; i--)
            {
                this.storage[i] = this.storage[i - 1];
            }

            this.storage[index] = element;
            this.Count++;
        }

        private void CheckIndexIsInRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }

        private void ResizeIfNeeded()
        {
            if (this.Count >= this.Capacity - 1)
            {
                this.Resize();
            }
        }
    }
}