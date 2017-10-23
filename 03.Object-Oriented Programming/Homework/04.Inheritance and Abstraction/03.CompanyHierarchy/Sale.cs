using System;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy
{
    public class Sale : ISale
    {
        private string productName;

        private DateTime date;

        private decimal price;

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name cannot be empty");
                }
                this.productName = value;
            }
        }

        public DateTime Date { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price of product cannot be negative");
                }
                this.price = value;
            }
        }

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public override string ToString()
        {
            string output = $"Product name: {this.ProductName}\nDate: {this.Date}\nPrice: {this.Price}\n";
            return output;
        }
    }
}