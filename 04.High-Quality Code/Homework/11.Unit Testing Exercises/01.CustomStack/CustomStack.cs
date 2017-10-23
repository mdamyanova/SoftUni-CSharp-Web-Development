namespace _01.CustomStack
{
    using System;

    public class CustomStack<T>
    {
        private const uint DefaultCapacity = 16;
        private T[] items;


        public CustomStack(uint capacity = DefaultCapacity)
        {
            this.items = new T[capacity];
            this.Count = 0;
            this.Capacity = capacity;
        }

        public int Count { get; private set; }

        public uint Capacity { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.Capacity)
            {
                 this.Resize();   
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.ValidateNotEmpty();

            int lastItemIndex = this.Count - 1;
            var item = this.items[lastItemIndex];

            this.items[lastItemIndex] = default(T);
            this.Count--;

            return item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }              
            }

            return false;
        }

        public T Peek()
        {
            this.ValidateNotEmpty();

            return this.items[this.Count - 1];
        }

        private void ValidateNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        public void Clear()
        {
            Array.Clear(this.items, 0, this.Count - 1);
            this.Count = 0;
        }

        private void Resize()
        {
            var newArray = new T[this.Capacity * 2];
            Array.Copy(this.items, newArray, this.Count);

            this.items = newArray;
            this.Capacity *= 2;
        }
    }
}