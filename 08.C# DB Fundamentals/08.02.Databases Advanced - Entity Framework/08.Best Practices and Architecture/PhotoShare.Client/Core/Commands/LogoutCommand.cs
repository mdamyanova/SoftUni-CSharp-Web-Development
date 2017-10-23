namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;

    public class LogoutCommand
    {
        public string Execute()
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first in order to logout!");
            }
            User user = AuthenticationManager.GetCurrentUser();
            AuthenticationManager.Logout();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
