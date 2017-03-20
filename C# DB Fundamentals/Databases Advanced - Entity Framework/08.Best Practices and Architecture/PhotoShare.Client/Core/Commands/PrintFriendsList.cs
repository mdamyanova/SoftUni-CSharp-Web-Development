namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;

    public class PrintFriendsListCommand 
    {
        private UserService userService;

        public PrintFriendsListCommand(UserService userService)
        {
            this.userService = userService;
        }

        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            if (!this.userService.IsUsernameExisting(username))
            {
                throw new InvalidOperationException($"Username [{username}] not found!");
            }

            var friends = this.userService.GetUserFriends(username);
            if (friends.Count == 0)
            {
                return "No friends for this user!";
            }
            return $"Friends for {username}: \n{String.Join("\n", friends)}";
        }
    }
}
