using System;

namespace _02.Customer
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null");
                }
                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            var output = $"Product name: {this.ProductName}, Price: {this.Price}{Environment.NewLine}";

            return output;
        }
    }
}