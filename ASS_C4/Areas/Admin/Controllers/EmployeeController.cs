using ASS_C4.Areas.Admin.ViewModel;
using ASS_C4.Helper;
using ASS_C4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ASS_C4.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class EmployeeController : Controller
    {
        private readonly OldSkoolContext _context;
        public EmployeeController(OldSkoolContext context)
        {
            _context = context;
        }
        public void ViewBagActive()
        {
            ViewBag.Active = "Employee";
        }
        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            ViewBagActive();
            var product = await (from x in _context.Employees
                           where x.IsDelete == false
                           select x).FirstOrDefaultAsync();
            ViewBag.product = product;
            return View();
        }
        // GET: RolesController/Create
        public ActionResult Create()
        {
            ViewBag.Active = "Product";
            return View();
        }
        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Employee employee, ICollection<IFormFile> Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee emp = new Employee();
                    emp.IdEmployee = new Guid();
                    emp.NameEmployee = employee.NameEmployee;
                    emp.Address = employee.Address;
                    emp.Phone = employee.Phone;
                    emp.Birthday = employee.Birthday;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ) ;
                    emp.Email = employee.Email;
                    emp.IsActice = true;
                    emp.IsOnline = false;
                    emp.Password = "123";
                    emp.RoleId = employee.RoleId;
                  
                    foreach (var file in Image)
                    {
                        emp.Image = Ultility.WriteFile(file, "Employee", emp.IdEmployee.ToString());

                    }
                    _context.Add(emp);            
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
            //var product = _context.Products.Find(id);
            var emp = (from x in _context.Employees
                       where x.IdEmployee == id
                       select x).FirstOrDefault();
            return Json(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp, ICollection<IFormFile> files)
        {

            // Xử lý cập nhật nhân viên
            var result = _context.Employees.Find(emp.IdEmployee);
            result.NameEmployee = emp.NameEmployee;
            result.Address = emp.Address;
            result.Phone = emp.Phone;
            result.Birthday = emp.Birthday;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ) ;
            result.Email = emp.Email;
            //result.IsActice = true;
            //result.IsOnline = false;
            result.RoleId = emp.RoleId;
            foreach (var file in files)
            {
                result.Image = Ultility.WriteFile(file, "Employee", emp.IdEmployee.ToString());
            }       
            _context.Employees.Update(result);       
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: RolesController/Delete/5
        [Route("Product/Delete/{id}")]
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            // Code to delete item with id in the database
            bool result = false;
            var product = _context.Employees.FirstOrDefault(s => s.IdEmployee == id);
            if (product != null)
            {
                product.IsDelete = true;
                _context.SaveChanges();
                result = true;
            }
            return Json(result);
        }
    }
}
