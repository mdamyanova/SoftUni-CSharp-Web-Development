namespace BankSystem.Client.Commands.BankAccountCommands
{
    using System;
    using System.Linq;
    using System.Text;
    using BankSystem.Client.IO;
    using BankSystem.Data;
    using BankSystem.Models.BankAccounts;

    public static class AddBankAccountCommand
    {
        public static void AddBankAccount(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            // doesn't work because we have two different tables 
            //var currentAssembly = Assembly.GetExecutingAssembly();
            //var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == accountType);
            //var account = (BankAccount)Activator.CreateInstance(currentType);

            var accountType = tokens[0];
            var initialBalance = decimal.Parse(tokens[1]);
            var interestRateOrFee = decimal.Parse(tokens[2]);
            var accountNumber = GetRandomAccountNumber();

            try
            {
                switch (accountType)
                {
                    case "SavingsAccount":
                        db.Users.FirstOrDefault(u => u.IsLogged).SavingAccounts
                            .Add(new SavingsAccount(accountNumber, initialBalance, interestRateOrFee));
                        break;
                    case "CheckingAccount":
                        db.Users.FirstOrDefault(u => u.IsLogged).CheckingAccounts
                            .Add(new CheckingAccount(accountNumber, initialBalance, interestRateOrFee));
                        break;
                    default:
                        writer.WriteLine(Messages.UnknownCommand);
                        break;
                }

                db.SaveChanges();
                writer.WriteLine(string.Format(Messages.SuccessAddAccount, accountNumber));
            }
            catch (Exception)
            {
               writer.WriteLine(Messages.NotLoggedInUser);
            }         
        }

        private static string GetRandomAccountNumber()
        {
            var random = new Random();
            var allowedLettersAndDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var length = 10;
            var builder = new StringBuilder();


            for (var i = 0; i < length; i++)
            {
                var c = allowedLettersAndDigits[random.Next(0, allowedLettersAndDigits.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}