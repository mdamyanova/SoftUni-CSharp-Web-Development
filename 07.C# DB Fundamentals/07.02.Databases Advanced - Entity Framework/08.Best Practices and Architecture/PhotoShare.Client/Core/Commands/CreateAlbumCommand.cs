namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;
    using System.Linq;
    using Utilities;

    public class CreateAlbumCommand
    {
        private readonly AlbumService albumService;
        private readonly TagService tagService;
        private readonly UserService userService;

        public CreateAlbumCommand(AlbumService albumService, UserService userService, TagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }
        
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>

        public string Execute(string[] commandParameters)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to create albums!");
            }
            string username = commandParameters[0];
            string albumTitle = commandParameters[1];
            string BgColor = commandParameters[2];
            string[] tags = commandParameters.Skip(3).Select(t=>TagUtilities.ValidateOrTransform(t)).ToArray();

            if (!this.userService.IsUsernameExisting(username))
            {
                throw new ArgumentException($"Username [{username}] not found!");
            }
            if (this.albumService.IsAlbumExisting(albumTitle))
            {
                throw new ArgumentException($"Album [{albumTitle}] is already existing!");
            }

            Color color;
            bool isColorValid = Enum.TryParse(BgColor, out color);
            if (!isColorValid)
            {
                throw new ArgumentException($"Color [{BgColor}] not found!");
            }
            if (tags.Any(t => !this.tagService.IsTagExisting(t)))
            {
                throw new ArgumentException($"Invalid tags!");
            }

            // TODO chech album title and add to DB
            
            this.albumService.AddAlbum(username, albumTitle, color, tags);

            return $"Album [{albumTitle}] successfully created!";
        }
    }
}