namespace BankSystem.Client.Commands.BankAccountCommands
{
    using System;
    using System.Linq;
    using BankSystem.Client.IO;
    using BankSystem.Data;

    public static class AddInterestCommand
    {
        public static void AddInterest(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            var accountNumber = tokens[0];

            try
            {
                var account = db.SavingAccounts.FirstOrDefault(s => s.AccountNumber == accountNumber);

                account.AddInterest();
                db.SaveChanges();

                writer.WriteLine(string.Format(Messages.SuccessAddInterest, accountNumber, account.Balance));
            }
            catch (Exception)
            {
                writer.WriteLine(string.Format(Messages.CannotAddInterest, accountNumber));
            }
        }
    }
}