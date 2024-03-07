using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using PhoneStore.Models;
using PhoneStore.Models.Resority;
using PhoneStore.ViewModel;
using System.Collections.Generic;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PhoneStore.Controllers
{
    
    public class ProductController : Controller
    {
        IHostingEnvironment host;
        ISupplierRes srs;
        IProductRes prs;
        ICatagoryRes cat;
        public ProductController(IProductRes _prs , IHostingEnvironment _host, ISupplierRes _srs , ICatagoryRes _cat)
        {
            host = _host;
            prs = _prs;
            srs = _srs;
            cat = _cat;
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public IActionResult NameCheck(string Name, int Product_Id)
        {

            var std = prs.GetbyNamebyId(Name, Product_Id);

            if (std == null)

                return Json(true);

            else return Json($"product {Name} is already in use.");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult index(string item,int catagorgsId,int suppliersId) 
        {
            List<Product> pro = prs.Search(item, catagorgsId, suppliersId);
            List<Category> catag = cat.Getall();
            List<Supplier> sup = srs.Getall();
            SupplierproductcatagoryViewmodel Vm = new SupplierproductcatagoryViewmodel
            {
                Products = pro,
                categories = catag,
                suppliers = sup,
                //item = item,
                //catagorgsId = catagorgsId,
                //suppliersId = suppliersId
            };
            return View("Index", Vm);

        }
        public IActionResult Details(int Id)
        {
            Product ptd = prs.GetDetails(Id);

            return View(ptd);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            prs.Delete(Id);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult New()
        {
            
            ViewBag.cat = cat.Getall();
            ViewData["sup"]= srs.Getall();
            
            return View();
        }
        [HttpPost]
        public IActionResult save(Product dept)
        {
            if (ModelState.IsValid)
            {
                if (dept.File != null)
                {
                    string fileName = string.Empty;
                    string update = Path.Combine(host.WebRootPath, "Images"); ;
                    fileName = dept.File.FileName;
                    string fullpath = Path.Combine(update, fileName);
                    dept.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                    dept.Image = fileName;
                }

                prs.Adding(dept);
                return RedirectToAction("Index");
            }
            else { return View("New"); }
        }
        public IActionResult Edite(int Id)
        {
            ViewBag.cat = cat.Getall();
            ViewData["sup"] = srs.Getall();
            Product DEPT2 = prs.Getbyid(Id);

            return View( DEPT2);

        }
        public IActionResult save2(Product items, int Id)
        {

            if (ModelState.IsValid == true)
            {
                if (items.File != null)
                {
                    string fileName = string.Empty;
                    string update = Path.Combine(host.WebRootPath, "Images"); ;
                    fileName = items.File.FileName;
                    string fullpath = Path.Combine(update, fileName);
                    items.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                    items.Image = fileName;
                }
                prs.Edite(items, Id);
                return RedirectToAction("Index");
            }
            else { return View("New2"); }
        }
    }
}
