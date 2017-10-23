namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;

    public class MakeFriendsCommand
    {
        private UserService userService;

        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }

        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to add friends!");
            }
            string username = data[0];
            string username2 = data[1];

            if (AuthenticationManager.GetCurrentUser().Username != username)
            {
                throw new InvalidOperationException("You can only add friends to yourself!");
            }
            if (!this.userService.IsUsernameExisting(username))
            {
                throw new ArgumentException($"{username} not found!");
            }
            else if (!this.userService.IsUsernameExisting(username2))
            {
                throw new ArgumentException($"{username2} not found!");
            }


            if (this.userService.AreFriends(username, username2))
            {
                //TO DO
                throw new ArgumentException($"{username2} is already friend with {username}!");
            }

            this.userService.MakeFriends(username, username2);

            return $"Friend {username2} added to {username}";
        }
    }
}
