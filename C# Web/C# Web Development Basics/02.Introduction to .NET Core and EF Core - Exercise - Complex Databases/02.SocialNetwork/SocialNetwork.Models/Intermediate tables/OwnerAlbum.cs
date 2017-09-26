namespace SocialNetwork.Models.Intermediate_tables
{
    public class OwnerAlbum
    {
        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}