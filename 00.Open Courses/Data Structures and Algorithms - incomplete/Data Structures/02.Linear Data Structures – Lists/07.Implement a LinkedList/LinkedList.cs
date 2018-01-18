namespace _07.Implement_a_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using _07.Implement_a_LinkedList.Interfaces;

    public class LinkedList<T> : ILinkedList<T>
    {
        private IListNode<T> head;

        private IListNode<T> tail;

        public LinkedList()
        {
            this.Count = 0;
            this.head = null;
            this.tail = null;
        }

        public IListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                var currIndex = 0;
                IListNode<T> currNode = this.head;

                while (currNode != null)
                {
                    if (currIndex == index)
                    {
                        break;
                    }
                    currIndex++;
                    currNode = currNode.Next;
                }

                return currNode;
            }
        }

        public int Count { get; private set; }

        public ListNode<T> Add(T element)
        {
            var newNode = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;

            return newNode;
        }

        public void Remove(int index)
        {
            var forRemove = this[index];

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var nextNode = forRemove.Next;
                IListNode<T> prevNode = null;

                try
                {
                    prevNode = this[index - 1];
                }
                catch (IndexOutOfRangeException)
                {
                }

                if (prevNode == null)
                {
                    this.head = (ListNode<T>)nextNode;
                }
                else
                {
                    prevNode.Next = nextNode;
                }
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            var index = 0;
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            var index = 0;
            var indexFound = -1;

            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    indexFound = index;
                }

                index++;
            }

            return indexFound;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = (ListNode<T>)currentNode.Next;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}