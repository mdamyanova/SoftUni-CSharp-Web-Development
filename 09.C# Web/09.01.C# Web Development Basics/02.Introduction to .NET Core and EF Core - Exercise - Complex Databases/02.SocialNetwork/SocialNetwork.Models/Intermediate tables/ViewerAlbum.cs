namespace SocialNetwork.Models.Intermediate_tables
{
    public class ViewerAlbum
    {
        public int ViewerId { get; set; }

        public User Viewer { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}