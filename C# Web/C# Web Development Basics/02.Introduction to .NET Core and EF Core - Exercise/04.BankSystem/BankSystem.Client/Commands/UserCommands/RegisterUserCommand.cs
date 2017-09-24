namespace BankSystem.Client.Commands.UserCommands
{
    using System.Text.RegularExpressions;
    using BankSystem.Client.IO;
    using BankSystem.Data;
    using BankSystem.Models;

    public static class RegisterUserCommand
    {
        public static void RegisterUser(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            var username = tokens[0];
            var password = tokens[1];
            var email = tokens[2];

            if (ValidateUserData(username, password, email, writer))
            {
                db.Users.Add(new User(username, password, email, false));
                db.SaveChanges();

                writer.WriteLine(string.Format(Messages.SuccessRegisterUser, username));
            }
        }

        private static bool ValidateUserData(string username, string password, string email, OutputWriter writer)
        {
            var validUsername = ValidateUsername(username);
            var validPassword = ValidatePassword(password);
            var validEmail = ValidateEmail(email);

            if (validUsername && validPassword && validEmail)
            {
                return true;
            }
            if (!validUsername)
            {
                writer.WriteLine(Messages.IncorrectUsername);
            }
            if (!validPassword)
            {
                writer.WriteLine(Messages.IncorrectPassword);
            }
            if (!validEmail)
            {
                writer.WriteLine(Messages.IncorrectEmail);
            }

            return false;
        }

        private static bool ValidateUsername(string username)
        {
            var usernamePattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,}$";
            var regex = new Regex(usernamePattern);
            var isMatch = regex.IsMatch(username);

            return isMatch;
        }

        private static bool ValidatePassword(string password)
        {
            var passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{7,}$";
            var regex = new Regex(passwordPattern);
            var isMatch = regex.IsMatch(password);

            return isMatch;
        }

        private static bool ValidateEmail(string email)
        {
            var emailPattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            var regex = new Regex(emailPattern);
            var isMatch = regex.IsMatch(email);

            return isMatch;
        }
    }
}