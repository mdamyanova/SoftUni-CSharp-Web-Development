using System.ComponentModel.DataAnnotations;

namespace _01.StudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Resource Resource { get; set; }
    }
}