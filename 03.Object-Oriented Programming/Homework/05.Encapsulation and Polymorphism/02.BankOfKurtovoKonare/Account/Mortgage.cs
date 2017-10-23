namespace _02.BankOfKurtovoKonare.Account
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double Balance { get; set; }
        public override double CalculateInterestRate(int months)
        {
            this.InterestRate = this.Customer.Money * (1 + this.InterestRate * months);

            if (this.Customer.Entity == Entity.Company && months <= 12)
            {
                return this.InterestRate / 2;
            }

            else if (this.Customer.Entity == Entity.Individual && months <= 6)
            {
                return 0;
            }
            return this.InterestRate;
        }
    }
}