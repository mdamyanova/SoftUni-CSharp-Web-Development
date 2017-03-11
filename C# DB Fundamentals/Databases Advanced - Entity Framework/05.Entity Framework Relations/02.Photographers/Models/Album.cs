using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02.Photographers.Models
{
    public class Album
    {
        public Album()
        {
            this.Photographers = new HashSet<PhotographerAlbum>();
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
        }    
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<PhotographerAlbum> Photographers { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}