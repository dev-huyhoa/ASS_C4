using ASS_C4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using ASS_C4.Areas.Admin.ViewModel;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
            viewAllCategory();
            var product = await (from x in _context.Products
                                 join z in _context.Categories
                                 on x.CategoryId equals z.IdCategory

                                 join y in _context.ListProduct
                                 on x.IdProduct equals y.ProductId
                                 where x.IsDelete == false       
                                 select new ProductViewModel
                                 {
                                     IdProduct = x.IdProduct,
                                     NameProduct = x.NameProduct,
                                     Image = x.Image,
                                     Price = x.Price,
                                     PricePromotion = x.PricePromotion,
                                     Decription = x.Decription,
                                     Status = x.Status,
                                     ModifyDate = x.ModifyDate,
                                     Size = y.Size,
                                     Quantity = y.Quantity,
                                     NameCategory = z.NameCategory
                                 }).ToListAsync();      
            ViewBag.product = product;
            return View();
        }
        // GET: RolesController/Create
        public ActionResult Create()
        {
            ViewBag.Active = "Product";
            return View();
        }
        public void viewAllCategory()
        {
            var result = (from x in _context.Categories
                          select x).ToList();
            ViewBag.viewAllCategory = result;
        }
        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductViewModel productView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product product = new Product();
                    product.IdProduct = new Guid();
                    product.NameProduct = productView.NameProduct;
                    product.Price = productView.Price;
                    product.PricePromotion = productView.PricePromotion;
                    product.Image = productView.Image;
                    product.Decription = productView.Decription;
                    product.CategoryId = productView.CategoryId;
                    product.Status = true;
                    product.ModifyDate = Helper.Ultility.ConvertDatetimeToUnixTimeStampMiliSecond(DateTime.Now);
                    product.IsDelete = false;
                    _context.Add(product);

                    ListProduct listProduct = new ListProduct();
                    listProduct.IdListProduct = new Guid();
                    listProduct.ProductId = product.IdProduct;
                    listProduct.Quantity = productView.Quantity;
                    listProduct.Size = productView.Size;
                    _context.Add(listProduct);

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
            var product = (from x in _context.Products
                           join z in _context.Categories
                           on x.CategoryId equals z.IdCategory

                           join y in _context.ListProduct
                           on x.IdProduct equals y.ProductId
                           where x.IdProduct == id
                           select new ProductViewModel
                           {
                               IdProduct = x.IdProduct,
                               CategoryId = x.CategoryId,
                               NameProduct = x.NameProduct,
                               Image = x.Image,
                               Price = x.Price,
                               PricePromotion = x.PricePromotion,
                               Decription = x.Decription,
                               Status = x.Status,
                               ModifyDate = x.ModifyDate,
                               Size = y.Size,
                               Quantity = y.Quantity,
                               NameCategory = z.NameCategory
                           }).ToList();
            return Json(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product, ICollection<IFormFile> files)
        {
            
            // Xử lý cập nhật sản phẩm
            var result = _context.Products.Find(product.IdProduct);
            result.NameProduct = product.NameProduct;
            result.PricePromotion = product.PricePromotion;
            result.Price = product.Price;
            result.Image = product.Image;
            result.CategoryId = product.CategoryId;
            result.Status = false;
            result.IsDelete = false;
            result.Decription = product.Decription;
            _context.Products.Update(result);

            product.ProductId = result.IdProduct;
            var ListProduct = (from x in _context.ListProduct
                               where x.ProductId == product.IdProduct
                               select x).FirstOrDefault();
                               
            ListProduct.Size = product.Size;
            ListProduct.Quantity = product.Quantity;
            _context.ListProduct.Update(ListProduct);

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
            var product = _context.Products.FirstOrDefault(s => s.IdProduct == id);
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
