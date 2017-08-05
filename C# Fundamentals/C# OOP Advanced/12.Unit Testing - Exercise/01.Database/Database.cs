using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Database
{
    public class Database
    {
        private const int DataCapacity = 16;
        private List<int> data;

        public Database(params int[] ints)
        {
            if (ints.Length <= DataCapacity)
            {
                this.Data = new List<int>(ints);
            }
            else
            {
                throw new InvalidOperationException($"Elements can't be more than {DataCapacity} characters long.");
            }
        }

        public List<int> Data
        {
            get => data;
            set
            {
                if (value.Count > DataCapacity)
                {
                    throw new InvalidOperationException("Data can't be more than 16 integers.");
                }

                this.data = value;
            }
        }

        public int Count => this.Data.Count;

        public void Add(int element)
        {
            if (this.Data.Count >= DataCapacity)
            {
                throw new InvalidOperationException("Can't add more elements.");
            }
            
            this.Data.Add(element);
        }

        public void Remove()
        {
            if (this.Data.Count == 0 || this.Data == null)
            {
                throw new InvalidOperationException("Data is empty.");
            }

            this.Data.Remove(this.Data[this.Data.Count - 1]);
        }

        public int[] Fetch()
        {
            return this.Data.ToArray();
        }
    }
}