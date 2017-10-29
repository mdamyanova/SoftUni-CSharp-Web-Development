namespace _03.ImplementAnArray_BasedStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using _03.ImplementAnArray_BasedStack.Interfaces;

    public class ArrayStack<T> : IArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {           
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
        } 

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Capacity { get; private set; }

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
                throw new ArgumentNullException("Cannot pop from empty stack");    
            }

            this.Count--;
            var element = this.elements[this.Count];
            this.elements[this.Count] = default(T);

            return element;
        }

        public T[] ToArray()
        {
            var subArray = new T[this.Count];

            Array.Copy(this.elements, subArray, this.Count);
            Array.Reverse(subArray);

            return subArray;
        }

        private void Grow()
        {
            this.Capacity *= 2;
            var newElements = new T[this.Capacity];

            Array.Copy(this.elements, newElements, this.Count);

            this.elements = newElements;
        }
    }
}