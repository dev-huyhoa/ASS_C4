using ASS_C4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASS_C4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly OldSkoolContext _context;
        public CategoryController(OldSkoolContext context)
        {
            _context = context;
        }
        public void ViewBagActive()
        {
            ViewBag.Active = "Category";
        }
        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            ViewBagActive();
            var category = await (from x in _context.Categories
                                  where x.IsDeleted == false
                                  select x).ToListAsync();
            ViewBag.category = category;
            return View();
        }
        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.IdCategory = new Guid();
                    category.IsDeleted = false;
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = _context.Categories.Find(id);
            return Json(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            // Xử lý cập nhật sản phẩm
            var result = _context.Categories.Find(category.IdCategory);
            result.NameCategory = category.NameCategory;
            result.Alias = category.Alias;
            result.Description = category.Description;

            _context.Categories.Update(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CategoryController/Delete/5
        [Route("Category/Delete/{id}")]
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            // Code to delete item with id in the database
            bool result = false;
            var category = _context.Categories.FirstOrDefault(s => s.IdCategory == id);
            if (category != null)
            {
                category.IsDeleted = true;
                _context.SaveChanges();
                result = true;
            }
            return Json(result);
        }
    }
}