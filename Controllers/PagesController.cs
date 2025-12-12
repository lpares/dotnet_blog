using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Article()
        {
            return View();
        }
    }
}
