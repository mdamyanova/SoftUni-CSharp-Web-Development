namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Models.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Infrastructure.Filters;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }

    [HttpPost]
    [ValidateModelState]
    public async Task<IActionResult> Create(PublishArticleFormModel model)
    {
        //TODO
    }
}