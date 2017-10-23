using System;
using System.Text;
using _03.GenericList._04.VersionAttribute;

namespace _03.GenericList 
{
    [Version(1,2)]
    public class GenericList<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        private int count;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];          
        }

        public int Count { get { return this.count; } }

        public void Add(T element)
        {
            if (this.count >= this.elements.Length)
            {
                this.IncreaseCapacity();
            }
            this.elements[count] = element;
            this.count++;
        }

        public T ElementAt(int index)
        {
            ValidateIndex(index);

            return elements[index];
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < this.count - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
            this.count--;
        }

        public void InsertAt(T element, int index)
        {
            ValidateIndex(index);

            if (count == elements.Length)
            {
               IncreaseCapacity();
            }       
             
            for (int i = count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.count++;
            this.elements[index] = element;
       }

        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.count = 0;
        }

        public int IndexOf(T element)
        {          
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(T element)
        {
            bool contain = false;
            int index = this.IndexOf(element);
            if (index != -1)
            {
                contain = true;
            }

            return contain;
        }

        public override string ToString()
        {
            if (this.count == 0)
            {
                return "The list is empty";
            }
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.count; i++)
            {
                sb.AppendLine($"Index {i.ToString().PadRight(3)} : {this.elements[i]}");
            }
            return sb.ToString();
        }

        private void IncreaseCapacity()
        {
            T[] doubledArray = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                doubledArray[i] = elements[i];
            }
            this.elements = doubledArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index cannot be negative");
            }
            if (index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Index must be in the array's range");
            }
        }     
    }
}