namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    public class PublishArticleFormModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}