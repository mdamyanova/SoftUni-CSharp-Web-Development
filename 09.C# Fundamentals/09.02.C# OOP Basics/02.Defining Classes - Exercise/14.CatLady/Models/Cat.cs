using System;

namespace _14.CatLady.Models
{
    public abstract class Cat
    {
        protected Cat(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}