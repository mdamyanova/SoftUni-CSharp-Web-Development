using System.Collections.Generic;
using _09.CollectionHierarchy.Interfaces;

namespace _09.CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Items = new List<string>();
        }

        public List<string> Items { get; }

        public int Add(string item)
        {           
            this.Items.Add(item);
            return this.Items.Count - 1;
        }
    }
}