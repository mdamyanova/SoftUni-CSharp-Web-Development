using System;
using System.Globalization;

namespace _03.PCCatalog
{
    public class Computer
    {
        private string name;
        private Component hdd;
        private Component processor;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("Name of computer cannot be empty");
                }
                this.name = value;
            }
        }

        public Component Hdd { get; set; }

        public Component Processor { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price of computer cannot be negative");
                }
                this.price = value;
            }
        }

        public Computer(string name, Component hdd, Component processor, decimal price)
        {
            this.Name = name;
            this.Hdd = hdd;
            this.Processor = processor;
            this.Price = price;
        }

        public Computer(string name, decimal price) : this(name, null, null, price)
        {
           
        }

        public override string ToString()
        { 
            decimal totalPrice = this.Price;
            string output = $"Name: {this.Name}\n";
            if (this.Hdd != null)
            {
                output += $"HDD: {this.Hdd.Name}\n";
                if (this.Hdd.Details != null)
                {
                    output += $"Details: {this.Hdd.Details}\n";
                }
                totalPrice += Hdd.Price;
                output += $"Processor: {this.Processor.Name}\n";
                if (this.Processor.Details != null)
                {
                    output += $"Details: {this.Processor.Details}\n";
                }
                totalPrice += Processor.Price;
            }
            output += $"Total price: {totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("bg-BG"))}\n";
            return output;
        }
    }
}