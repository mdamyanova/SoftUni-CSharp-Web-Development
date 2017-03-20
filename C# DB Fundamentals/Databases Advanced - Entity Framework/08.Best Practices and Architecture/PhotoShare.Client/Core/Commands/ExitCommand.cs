namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public string Execute()
        {
            if (AuthenticationManager.IsAuthenticated())
            {
                AuthenticationManager.Logout();
            }
            Environment.Exit(0);
            return "Bye-bye";


        }
    }
}
