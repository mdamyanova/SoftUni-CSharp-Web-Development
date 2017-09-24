namespace BankSystem.Client.Commands.BankAccountCommands
{
    using System.Linq;
    using BankSystem.Client.IO;
    using BankSystem.Data;

    public static class ListAccountsCommand
    {
        public static void ListAccounts(BankSystemDbContext db, OutputWriter writer)
        {
            var result = db
                .Users
                .Where(u => u.IsLogged)
                .Select(u => new
                {
                    u.Username,
                    SavingAccounts = u
                        .SavingAccounts
                        .Select(s => new
                        {
                            s.AccountNumber,
                            s.Balance
                        }),
                    CheckingAccounts = u
                        .CheckingAccounts
                        .Select(c => new
                        {
                            c.AccountNumber,
                            c.Balance
                        })
                })
                .FirstOrDefault();

            writer.WriteLine($"Accounts for user {result.Username}:");
            writer.WriteLine("Saving Accounts:");

            foreach (var account in result.SavingAccounts)
            {
                writer.WriteLine($"--{account.AccountNumber} {account.Balance}");
            }

            writer.WriteLine("Checking Accounts:");

            foreach (var account in result.CheckingAccounts)
            {
                writer.WriteLine($"--{account.AccountNumber} {account.Balance}");
            }
        }   
    }
}