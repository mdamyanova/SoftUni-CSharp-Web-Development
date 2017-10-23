namespace BankSystem.Client.Commands.UserCommands
{
    using System.Linq;
    using BankSystem.Client.IO;
    using BankSystem.Data;

    public class LoginLogoutUser
    {
        public static void LoginUser(BankSystemDbContext db, string[] tokens, OutputWriter writer)
        {
            var username = tokens[0];
            var password = tokens[1];
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                user.IsLogged = true;
                db.SaveChanges();

                writer.WriteLine(string.Format(Messages.SuccessLogin, username));
            }
            else
            {
                writer.WriteLine(Messages.CannotLogin);
            }
        }

        public static void LogoutUser(BankSystemDbContext db, OutputWriter writer)
        {
            // I assume that there's only one logged in user in db
            if (!db.Users.Any())
            {
                writer.WriteLine(Messages.CannotLogout);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.IsLogged);

                if (user != null && user.IsLogged)
                {
                    user.IsLogged = false;                   
                    db.SaveChanges();

                    writer.WriteLine(string.Format(Messages.SuccessLogout, user.Username));
                }
                else
                {
                    writer.WriteLine(Messages.CannotLogout);
                }
            }          
        }
    }
}