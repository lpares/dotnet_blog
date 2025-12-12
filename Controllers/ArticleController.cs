using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Update()
        {
            return View();
        }

        [Authorize]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
