using Microsoft.AspNetCore.Mvc;

namespace ASS_C4.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
