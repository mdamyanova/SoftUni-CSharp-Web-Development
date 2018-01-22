namespace _03.Array_BasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            this.Count--;
            var element = this.elements[this.Count];
            this.elements[this.Count] = default(T);

            return element;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            Array.Copy(this.elements, array, this.Count);
            Array.Reverse(array);

            return array;
        }

        private void Grow()
        {
            var newArray = new T[2 * this.elements.Length];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }
    }
}