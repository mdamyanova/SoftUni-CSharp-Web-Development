namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;

    public class UploadPictureCommand
    {
        private AlbumService albumService;
        private PictureService pictureService;

        public UploadPictureCommand(AlbumService albumService, PictureService pictureService)
        {
            this.albumService = albumService;
            this.pictureService = pictureService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>

        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to upload pictures!");
            }
            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];


            //TO DO: •	Upload picture (only if he is owner of the album that picture is uploaded to)



            if (!this.albumService.IsAlbumExisting(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }
            if (this.pictureService.IsPicExisting(albumName, pictureTitle, pictureFilePath))
            {
                throw new ArgumentException($"Picture {pictureTitle} already existing in album {albumName}!");
            }
            this.pictureService.AddPicture(albumName,pictureTitle, pictureFilePath);

            return $"Picture {pictureTitle} added to album {albumName}";

        }
    }
}
