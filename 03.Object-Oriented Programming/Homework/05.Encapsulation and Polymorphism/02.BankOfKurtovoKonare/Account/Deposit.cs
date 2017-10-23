using System;

namespace _02.BankOfKurtovoKonare.Account
{
    public class Deposit : Account
    {
        private double balance;

        public Deposit(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance of deposit cannot be negative");
                }
                this.balance = value;
            }
        }

        public override double CalculateInterestRate(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            
            return this.Customer.Money*(1 + this.InterestRate*months);
        }
    }
}