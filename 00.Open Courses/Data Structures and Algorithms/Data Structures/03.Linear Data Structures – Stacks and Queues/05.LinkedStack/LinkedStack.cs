namespace _05.LinkedStack
{
    using System;
    using System.CodeDom;
    using System.Data;

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
                throw new ArgumentNullException("Cannot pop from empty stack");
            }

            var result = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return result.Value;
        }

        public T[] ToArray()
        {
            var subArray = new T[this.Count];
            var currNode = this.firstNode;
            var arrIndex = 0;

            while (currNode != null)
            {
                subArray[arrIndex] = currNode.Value;
                arrIndex++;
                currNode = currNode.NextNode;
            }

            return subArray;
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