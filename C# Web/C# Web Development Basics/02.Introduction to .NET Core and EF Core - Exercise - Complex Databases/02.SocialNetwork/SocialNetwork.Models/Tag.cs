namespace SocialNetwork.Models
{
    using System.Collections.Generic;
    using SocialNetwork.Models.Intermediate_tables;
    using SocialNetwork.Models.Validations;

    public class Tag
    {
        public int Id { get; set; }

        [Tag]
        public string TagValue { get; set; }

        public List<AlbumTag> Albums { get; set; } = new List<AlbumTag>();
    }
}