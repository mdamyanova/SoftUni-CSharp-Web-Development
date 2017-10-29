namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;

        private QueueNode<T> tail;
         
        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                var newHead = new QueueNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;

            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("Cannot dequeue from empty linked queue");
            }

            var element = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            var newArr = new T[this.Count];   
            var currentNode = this.head;
            var arrIndex = 0;

            while (currentNode != null)
            {
                newArr[arrIndex] = currentNode.Value;
                arrIndex++;
                currentNode = currentNode.NextNode;
            }

            return newArr;
        }

        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            } 

            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
        }
    }

}