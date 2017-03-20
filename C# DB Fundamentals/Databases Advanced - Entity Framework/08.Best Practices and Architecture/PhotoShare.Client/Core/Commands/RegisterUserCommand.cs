namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;

    public class RegisterUserCommand
    {
        private readonly UserService userservice;

        public RegisterUserCommand(UserService userservice)
        {
            this.userservice = userservice;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }
            if (this.userservice.IsUsernameExisting(username))
            {
                throw new InvalidOperationException($"Username [{username}] is already taken!");
            } 
           
            this.userservice.RegisterUser(username,password,email);
           
            return "User " + username + " was registered successfully!";
        }
    }
}
