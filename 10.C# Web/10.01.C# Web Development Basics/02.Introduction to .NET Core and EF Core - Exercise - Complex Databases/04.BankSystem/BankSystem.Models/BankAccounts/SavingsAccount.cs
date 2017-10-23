namespace BankSystem.Models.BankAccounts
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount()
        {
            
        }

        public SavingsAccount(string accountNumber, decimal balance, decimal interestRate) : 
            base(accountNumber, balance)
        {
            this.InterestRate = interestRate;
        }

        public decimal InterestRate { get; set; }

        public void AddInterest()
        {
            this.Balance += this.InterestRate;
        }
    }
}