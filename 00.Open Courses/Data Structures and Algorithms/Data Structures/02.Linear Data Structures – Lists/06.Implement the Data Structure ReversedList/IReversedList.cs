namespace _06.Implement_the_Data_Structure_ReversedList
{
    using System.Collections.Generic;

    public interface IReversedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        int Capacity { get; }

        /// <summary>
        /// Access the element by index in the reverse order of adding.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        T this[int index] { get; set; }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Add(T item);

        /// <summary>
        /// Removes the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        void Remove(int index);
    }
}