using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._09._10.CustomList.Models
{
    public class CustomList<T> where T : IComparable<T>
    {
        public CustomList()
        {
            this.Data = new List<T>();
        }

        public CustomList(List<T> list)
        {
            this.Data = list;
        }

        public List<T> Data { get; set; }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public T Remove(int index)
        {
            var element = this.Data.ElementAt(index);
            this.Data.RemoveAt(index);
            return element;
        }

        public bool Contains(T element)
        {
            return this.Data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var firstElement = this.Data.ElementAt(index1);

            this.Data[index1] = this.Data.ElementAt(index2);
            this.Data[index2] = firstElement;
        }

        public int CountGreaterThan(T element)
        {
            return this.Data.Count(item => item.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.Data.Max();
        }

        public T Min()
        {
            return this.Data.Min();
        }
    }
}