
using BookStoreWeb.Data;
using BookStoreWeb.Data.Repository.IRepository;
using BookStoreWeb.Models;
using BookStoreWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace bookStoreWeb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork db, IWebHostEnvironment hostEnv)
        {
            _db = db;
            _webHostEnvironment = hostEnv;
        }

        //GET Book
        public IActionResult Index()
        {
            IEnumerable<ProductModel> productList = _db.Products.GetAll(includeProp: "Category,CoverType");

            return View(productList);
        }


        //Render Create Form
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _db.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoverTypeList = _db.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                ProductModel product = _db.Products.GetFirstOrDefault(u => u.Id == id);
                productVM.Product = product;
                return View(productVM);
            }

        }

        //Post Created/Edited Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Product.ImageUrl != null)
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, obj.Product.ImageUrl.Trim('\\'));
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams); //filestream is the stream created to copy the file and save it in the given location(wwwroot)
                    }

                    obj.Product.ImageUrl = @"\Images\Products\" + fileName + extension;
                }
                if (obj.Product.Id == 0)
                {

                    _db.Products.Add(obj.Product);
                }
                else
                {
                    _db.Products.Update(obj.Product);
                }
                _db.Save();
                TempData["Success"] = "Category successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API End points

        public IActionResult getAll()
        {
            var productList = _db.Products.GetAll(includeProp: "Category,CoverType");
            return Json(new { data = productList });
        }
        [HttpGet]// httpget for delete because to retreive ID from params..
        public IActionResult Delete(int? id)
        {
            var userDetails = _db.Products.GetFirstOrDefault(item => item.Id == id);
            if (userDetails == null)
            {
                return Json(new { Error = true,message="Error while deleting"});
            }

            var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, userDetails.ImageUrl.Trim('\\'));
            if (System.IO.File.Exists(oldImageUrl))
            {
                System.IO.File.Delete(oldImageUrl);
            }

            _db.Products.Remove(userDetails);
            _db.Save();
            return Json(new { Error = false,message="Delete success"});
        }
        #endregion

    }
}
