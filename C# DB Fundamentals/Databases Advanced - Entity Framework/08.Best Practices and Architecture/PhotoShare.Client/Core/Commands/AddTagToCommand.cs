namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;
    using Utilities;

    public class AddTagToCommand
    {
        private readonly AlbumService albumService;
        private readonly TagService tagService;

        // AddTagTo <albumName> <tag>
        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }

        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to add tag!");
            }
            string albumName = data[0];
            string tag = data[1].ValidateOrTransform();
            //TO DO: •	Add tag to picture (which is part of at least one album which he is owner of)
            if (!this.tagService.IsTagExisting(tag) || !this.albumService.IsAlbumExisting(albumName))
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            if (this.albumService.HasTag(tag))
            {
                throw new ArgumentException("Album already has this tag!");
            }
            this.albumService.AddTag(albumName, tag);

            return $"Tag {tag} was added successfully to {albumName}!";
        }

    }
}