namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.Blog.Contracts;
    using Services.Html;
    using System.Threading.Tasks;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(
            IHtmlService html, 
            IBlogArticleService articles,
            UserManager<User> userManager)
        {
            this.html = html;
            this.articles = articles;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            };

            return this.View(result);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return this.ViewOrNotFound(await this.articles.ByIdAsync(id));
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return this.RedirectToAction(nameof(Index));
        }
    }
}