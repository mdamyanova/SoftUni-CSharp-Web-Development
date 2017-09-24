namespace BankSystem.Client
{
    using System;
    using System.Linq;
    using BankSystem.Client.Commands.BankAccountCommands;
    using BankSystem.Client.Commands.UserCommands;
    using BankSystem.Client.IO;
    using BankSystem.Data;

    public static class CommandInterpreter
    {
        private static readonly BankSystemDbContext Db = new BankSystemDbContext();
        private static readonly InputReader Reader = new InputReader();
        private static readonly OutputWriter Writer = new OutputWriter();

        public static void Execute()
        {          
            using (Db)
            {
                Db.Database.EnsureDeleted();
                Db.Database.EnsureCreated();
                ProcessCommand();
            }
        }

        private static void ProcessCommand()
        {
            var line = Reader.ReadLine();

            while(!string.IsNullOrEmpty(line))
            {
                var lineTokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var tokens = lineTokens.Skip(1).ToArray();

                switch (lineTokens[0])
                {
                    case "Register":
                        RegisterUserCommand.RegisterUser(Db, tokens, Writer);
                        break;
                    case "Login":
                        LoginLogoutUser.LoginUser(Db, tokens, Writer);
                        break;
                    case "Logout":
                        LoginLogoutUser.LogoutUser(Db, Writer);
                        break;
                    case "Add":
                        AddBankAccountCommand.AddBankAccount(Db, tokens, Writer);
                        break;
                    case "ListAccounts":
                        ListAccountsCommand.ListAccounts(Db, Writer);
                        break;
                    case "Deposit":
                        DepositCommand.Deposit(Db, tokens, Writer);
                        break;
                    case "Withdraw":
                        WithdrawCommand.Withdraw(Db, tokens, Writer);
                        break;
                    case "DeductFee":
                        DeductFeeCommand.DeductFee(Db, tokens, Writer);
                        break;
                    case "AddInterest":
                        AddInterestCommand.AddInterest(Db, tokens, Writer);
                        break;
                    default:
                        Writer.WriteLine(Messages.UnknownCommand);
                        break;
                }

                line = Reader.ReadLine();
            }       
        }
    }
}