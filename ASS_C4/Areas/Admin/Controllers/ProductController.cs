using ASS_C4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASS_C4.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly OldSkoolContext _context;
        public ProductController(OldSkoolContext context)
        {
            _context = context;
        }
        public void ViewBagActive()
        {
            ViewBag.Active = "Product";
        }
        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            ViewBagActive();
            var product = await (from x in _context.Products
                              where x.IsDelete == false
                              select x).ToListAsync();
            ViewBag.product = product;
            return View();
        }
    }
}
