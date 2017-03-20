namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Services;

    public class DeleteUser
    {
        private readonly UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to upload pictures!");
            }

            string username = data[0];
            if (!this.userService.IsUsernameExisting(username))
            {
                throw new InvalidOperationException($"User with {username} was not found!");
            }

            if (AuthenticationManager.GetCurrentUser().Username != username)
            {
                throw new InvalidOperationException("You can delete only your profile!");
            }

            if (this.userService.IsDeleted(username))
            {
                throw new InvalidOperationException($"User with {username} is already deleted!");
            }
            this.userService.DeleteUser(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
