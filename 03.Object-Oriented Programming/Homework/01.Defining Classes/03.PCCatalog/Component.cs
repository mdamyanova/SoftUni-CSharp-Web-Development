using System;

namespace _03.PCCatalog
{
    public class Component
    {
        private string name;
        private string details;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Name of the component must be at least 3 chars long");
                }
                this.name = value;
            }
        }

        public string Details { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price of the component cannot be negative");
                }
                this.price = value;
            }
        }

        public Component(string name, string details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;       
        }

        public Component(string name, decimal price) : this(name, null, price)
        {

        }

        public override string ToString()
        {
            string output = $"Name: {this.name}\t";
            if (this.Details!= null)
            {
                output += $"Details: {this.details}\t";
            }
            output += $"Price: {this.price}\n";
            return base.ToString();
        }
    }
}