namespace _07.Implement_a_LinkedList
{
    using _07.Implement_a_LinkedList.Interfaces;

    public class ListNode<T> : IListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public IListNode<T> Next { get; set; }

        public T Value { get; }
    }
}