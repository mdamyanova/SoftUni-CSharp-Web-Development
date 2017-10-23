namespace _02.LinkedQueue
{
    public class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public QueueNode<T> NextNode { get; set; }
    }
}
