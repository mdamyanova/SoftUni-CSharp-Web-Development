namespace BankSystem.Client.Commands.BankAccountCommands
{
    using System;
    using System.Linq;
    using BankSystem.Client.IO;
    using BankSystem.Data;
    using BankSystem.Models;

    public static class WithdrawCommand
    {
        public static void Withdraw(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            var accountNumber = tokens[0];
            var money = decimal.Parse(tokens[1]);

            try
            {
                var account = db.SavingAccounts.FirstOrDefault(s => s.AccountNumber == accountNumber)
                          ?? (BankAccount)db.CheckingAccounts.FirstOrDefault(s => s.AccountNumber == accountNumber);

                account.WithdrawMoney(money);
                db.SaveChanges();

                writer.WriteLine(string.Format(Messages.SuccessWithdraw, accountNumber));
            }
            catch (Exception)
            {
                writer.WriteLine(string.Format(Messages.CannotWithdraw, accountNumber));
            }
        }
    }
}