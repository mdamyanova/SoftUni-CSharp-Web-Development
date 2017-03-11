using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentSystem.Enums;

namespace _01.StudentSystem.Models
{
    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}