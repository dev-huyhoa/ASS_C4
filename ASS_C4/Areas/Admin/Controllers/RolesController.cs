using ASS_C4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ASS_C4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly OldSkoolContext _context;
        public RolesController(OldSkoolContext context)
        {
            _context = context;
        }
        public void ViewBagActive()
        {
            ViewBag.Active = "Role";
        }
        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            ViewBagActive();
            var role = await (from x in _context.Roles
                              where x.IsDeleted == false
                              select x).ToListAsync();
            ViewBag.role = role;
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            ViewBag.Active = "Role";
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(role);
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
        //public IActionResult GetId(int idRoles)
        //{
        //    var role = _context.Roles.Find(idRoles);
        //    return Json(role);
        //}

        //[HttpPost]
        //public IActionResult Update(Role role)
        //{
        //    var result = _context.Roles.Find(role.IdRole);
        //    result.NameRole = role.NameRole;
        //    result.Description = role.Description;
        //    _context.Roles.Update(result);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Roles.Find(id);
            return Json(product);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            // Xử lý cập nhật sản phẩm
            var result = _context.Roles.Find(role.IdRole);
            result.NameRole = role.NameRole;
            result.Description = role.Description;

            _context.Roles.Update(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: RolesController/Delete/5
        [Route("Roles/Delete/{id}")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            // Code to delete item with id in the database
            bool result = false;
            var role = _context.Roles.FirstOrDefault(s => s.IdRole == id);
            if (role != null)
            {
                role.IsDeleted = true;
                _context.SaveChanges();
                result = true;
            }
            return Json(result);
        }
    }
}
