namespace _07.Implement_a_LinkedList.Interfaces
{
    using System.Collections.Generic;

    public interface ILinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        ListNode<T> Add(T element);

        /// <summary>
        /// Removes the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        void Remove(int index);

        /// <summary>
        /// Returns the first index of element.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        int FirstIndexOf(T item);

        /// <summary>
        /// Returns the last index of element.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        int LastIndexOf(T item);

        new IEnumerator<T> GetEnumerator();
    }
}