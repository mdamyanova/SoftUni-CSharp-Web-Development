namespace BankSystem.Client.IO
{
    public class Messages
    {
        public const string IncorrectUsername = "Incorrect username.";

        public const string IncorrectPassword = "Incorrect password.";

        public const string IncorrectEmail = "Incorrect email.";

        public const string SuccessRegisterUser = "{0} was registered in the system.";

        public const string CannotLogin = "Incorrect username / password.";

        public const string SuccessLogin = "Successfully logged in {0}.";

        public const string CannotLogout = "Incorrect username / password.";

        public const string SuccessLogout = "User {0} successfully logged out.";

        public const string UnknownCommand = "Unknown command.";

        public const string SuccessAddAccount = "Successfully added account with number {0}.";

        public const string SuccessDeposit = "Successfully deposit money to account with number {0}.";

        public const string CannotDeposit = "Cannot deposit money to account with number {0}.";

        public const string SuccessWithdraw = "Successfully withdraw money to account with number {0}.";

        public const string CannotWithdraw = "Cannot withdraw money to account with number {0}.";

        public const string SuccessDeductFee = "Deducted fee of {0}. Current balance: {1}.";

        public const string CannotDeductFee = "Cannot deduct fee to account with number {0}.";

        public const string SuccessAddInterest = "Added interest to {0}. Current balance: {1}.";

        public const string CannotAddInterest = "Cannot add interest to account with number {0}.";

        public const string NotLoggedInUser = "The user is not logged in.";
    }
}