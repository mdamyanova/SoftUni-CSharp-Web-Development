namespace _08.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; private set; }

            public Node Next { get; set; }

            public Node Prev { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newNode = new Node(element);

            if (IsEmpty())
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head.Prev = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var newNode = new Node(element);

            if (IsEmpty())
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Prev = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No elements!");
            }

            var firstElement = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Prev = null;
            }

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No elements!");
            }

            var lastElement = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }

            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var current = this.head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];

            var current = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }

            return arr;
        }

        private bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}