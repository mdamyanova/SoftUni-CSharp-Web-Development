using System;

namespace _03.CompanyHierarchy.Customer
{
    public class Customer : Person
    {
        private decimal netPurchaseAmount;

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The purchase amount cannot be negative");
                }
                this.netPurchaseAmount = value;
            }
        }

        public Customer(int id, string firstName, string lastName, decimal netPurchaseAmount) : 
            base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public override string ToString()
        {
            string output =
                $"Customer name: {this.FirstName} {this.LastName}\nId: {this.Id}\nPurchase amount: {this.NetPurchaseAmount}\n";
            return output;
        }
    }
}