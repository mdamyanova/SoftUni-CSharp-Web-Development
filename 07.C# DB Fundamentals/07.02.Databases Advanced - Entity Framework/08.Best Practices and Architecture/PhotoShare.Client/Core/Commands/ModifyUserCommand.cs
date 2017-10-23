namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;
    using Models;
    using System.Linq;

    public class ModifyUserCommand
    {
        private readonly TownService townService;
        private readonly UserService userService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Login in order to add friends!");
            }
            string username = data[0];
            string property = data[1];
            string value = data[2];

            if (!this.userService.IsUsernameExisting(username))
            {
                throw new ArgumentException($"Username {username} not found!");
            }

            User userToUpdate = this.userService.GetUserByUsername(username);


            if (AuthenticationManager.GetCurrentUser().Username != username)
            {
                throw new InvalidOperationException("You can only modify your own profile!");
            }
            if (property == "Password")
            {
                if (!(value.Any(c => char.IsLower(c)) && value.Any(c => char.IsDigit(c))))
                {
                    throw new ArgumentException("Invalid password!");
                }

                userToUpdate.Password = value;
            }
            else if (property.Equals("BornTown"))
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Town {value} not found!");
                }
                userToUpdate.BornTown = this.townService.GetTownByName(value);
            }
            else if (property.Equals("CurrentTown"))
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Town {value} not found!");
                }
                userToUpdate.CurrentTown = this.townService.GetTownByName(value);
            }
            else
            {
                throw new ArgumentException($"Property [{property}] not found");
            }

            this.userService.UpdateUser(userToUpdate);

            return $"User [{username}] [{property}] is [{value}]";
        }
    }
}