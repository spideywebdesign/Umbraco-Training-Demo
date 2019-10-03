using CoreProject.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using ContentModels = CoreProject.Models.Published;

namespace CoreProject.Controllers
{
    public class HomeController : RenderMvcController
    {
        private readonly IBlogService _blogService;
        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public ActionResult Home(ContentModels.Home model)
        {
            model.AllBlogPosts = _blogService.GetAllBlogPosts().ToArray();
            return View(model);
        }
    }
}