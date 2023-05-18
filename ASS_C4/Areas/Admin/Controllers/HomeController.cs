using Microsoft.AspNetCore.Mvc;

namespace ASS_C4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Active = "Home";
            return View();
        }
    }
}
