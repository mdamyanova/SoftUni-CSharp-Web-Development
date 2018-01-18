namespace _03.ImplementAnArray_BasedStack.Interfaces
{
    using System.Collections.Generic;

    public interface IArrayStack<T> : IEnumerable<T>
    {
        int Count { get; }

        void Push(T element);

        T Pop();

        T[] ToArray();
    }
}