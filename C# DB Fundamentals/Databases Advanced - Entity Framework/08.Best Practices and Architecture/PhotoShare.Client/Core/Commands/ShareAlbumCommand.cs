namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;
    using Models;

    public class ShareAlbumCommand
    {
        private AlbumService albumService;
        private UserService userService;

        public ShareAlbumCommand(AlbumService albumService, UserService userService)
        {
            this.albumService = albumService;
            this.userService = userService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer


        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to share albums!");
            }

            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            if (!this.albumService.IsAlbumExisting(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            Album album = this.albumService.GetAlbumById(albumId);
            if (!this.userService.IsUsernameExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            
            if (!this.userService.IsOwnerForAlbum(AuthenticationManager.GetCurrentUser().Id, albumId))
            {
                throw new InvalidOperationException("You can only share your albums!");
            }

            Role role;
            bool isRoleValid = Enum.TryParse(permission, out role);

            if (!isRoleValid)
            {
                throw new ArgumentException($"Permission must be either \"Owner\" or \"Viewer\"!");
            }

            if (this.albumService.isRoleExistingForUser(username, albumId, role))
            {
                throw new ArgumentException($"User {username} already has role in album {album.Name}!");
            }


            this.albumService.ShareAlbum(albumId, username, role);

            return $"Username {username} added to album {album.Name} ({permission})";
        }
    }
}
