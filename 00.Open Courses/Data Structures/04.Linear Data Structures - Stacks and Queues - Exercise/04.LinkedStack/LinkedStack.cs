using System;

namespace _04.LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return element;

        }

        public T[] ToArray()
        {
            var newArray = new T[this.Count];
            var currNode = this.firstNode;
            var arrIndex = 0;

            while (currNode != null)
            {
                newArray[arrIndex] = currNode.Value;
                arrIndex++;
                currNode = currNode.NextNode;
            }

            return newArray;
        }

        private class Node<T>
        {
            private T value;

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; private set; }

            public Node<T> NextNode { get; private set; }
        }
    }
}