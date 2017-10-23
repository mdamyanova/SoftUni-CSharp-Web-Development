using _02.BankOfKurtovoKonare.Interface;

namespace _02.BankOfKurtovoKonare.Account
{
    public abstract class Account : IInterestable
    {
        private double interestRate;

        protected Account(Customer customer, double balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }

        public abstract double Balance { get; set; }

        public double InterestRate { get; set; }

        public abstract double CalculateInterestRate(int months);
    }
}