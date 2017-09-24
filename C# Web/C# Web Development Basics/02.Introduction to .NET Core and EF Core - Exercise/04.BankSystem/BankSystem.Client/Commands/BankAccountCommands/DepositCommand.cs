namespace BankSystem.Client.Commands.BankAccountCommands
{
    using System;
    using System.Linq;
    using BankSystem.Client.IO;
    using BankSystem.Data;
    using BankSystem.Models;

    public static class DepositCommand
    {
        public static void Deposit(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            var accountNumber = tokens[0];
            var money = decimal.Parse(tokens[1]);

            try
            {
                var account = db.SavingAccounts.FirstOrDefault(s => s.AccountNumber == accountNumber)
                          ?? (BankAccount) db.CheckingAccounts.FirstOrDefault(s => s.AccountNumber == accountNumber);
            
                account.DepositMoney(money);
                db.SaveChanges();

                writer.WriteLine(string.Format(Messages.SuccessDeposit, accountNumber));
            }
            catch (Exception)
            {
                writer.WriteLine(string.Format(Messages.CannotDeposit, accountNumber));   
            }       
        }
    }
}