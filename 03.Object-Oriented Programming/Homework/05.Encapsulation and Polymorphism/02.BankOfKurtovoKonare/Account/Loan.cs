namespace _02.BankOfKurtovoKonare.Account
{
    public class Loan : Account
    {
        public Loan(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double Balance { get; set; }

        public override double CalculateInterestRate(int months)
        {
            if (this.Customer.Entity == Entity.Individual && months <= 3)
            {
                return 0;
            }
            if (this.Customer.Entity == Entity.Company && months <= 2)
            {
                return 0;
            }
            return this.Customer.Money*(1 + this.InterestRate*months);
        }
    }
}