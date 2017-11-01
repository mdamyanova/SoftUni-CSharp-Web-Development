namespace FluffyDuffyMunchkinCats.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        private const int MinLengthString = 1;
        private const int MaxLengthString = 50;
        private const int MaxAge = 30;
        private const int MaxLengthUrl = 2000;

        public int Id { get; set; }

        [Required]
        [MinLength(MinLengthString)]
        [MaxLength(MaxLengthString)]
        public string Name { get; set; }

        [Range(0, MaxAge)]
        public int Age { get; set; }

        [Required]
        [MinLength(MinLengthString)]
        [MaxLength(MaxLengthString)]
        public string Breed { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(MaxLengthUrl)]
        public string ImageUrl { get; set; }
    }
}