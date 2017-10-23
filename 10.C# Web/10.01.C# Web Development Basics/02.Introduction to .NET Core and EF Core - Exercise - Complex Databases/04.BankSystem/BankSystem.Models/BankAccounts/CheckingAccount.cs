namespace BankSystem.Models.BankAccounts
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount()
        {
            
        }

        public CheckingAccount(string accountNumber, decimal balance, decimal fee) : 
            base(accountNumber, balance)
        {
            this.Fee = fee;
        }

        public decimal Fee { get; set; }

        public void DeductFee()
        {
            this.Balance -= this.Fee;
        }
    }
}