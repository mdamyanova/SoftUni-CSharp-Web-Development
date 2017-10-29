namespace _07.Implement_a_LinkedList.Interfaces
{
    public interface IListNode<T>
    {
        IListNode<T> Next { get; set; }

        T Value { get; }
    }
}