
using BookStoreWeb.Data;
using BookStoreWeb.Data.Repository.IRepository;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace bookStoreWeb.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        //GET Book
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Category.GetAll();

            return View(categoryList);
        }

        //Get Book
        public IActionResult Create()
        {
            return View();
        }

        //Post Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot be Name");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.Save();
                TempData["Success"] = "Category successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Edit Book
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFrmDb = _db.Categories.Find(id);
            var categoryFrmDb = _db.Category.GetFirstOrDefault(item => item.Id == id);

            return View(categoryFrmDb);
        }

        //Post Edited Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            List<Category> userDetails = _db.Category.GetRepo().Where(u => u.Name == obj.Name).ToList();
            if (userDetails.Count >= 2)
            {
                ModelState.AddModelError("name", "Name already exist, Choose different Name");
            }

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot be Name");
            }
            if (ModelState.IsValid)
            {

                _db.Category.Update(obj);
                _db.Save();
                TempData["Success"] = "Category successfully edited";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get Edit Book
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFrmDb = _db.Category.GetFirstOrDefault(item => item.Id == id);

            return View(categoryFrmDb);
        }

        //Post Edited Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var userDetails = _db.Category.GetFirstOrDefault(item => item.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }
            _db.Category.Remove(userDetails);
            _db.Save();
            TempData["Success"] = "Category successfully deleted";
            return RedirectToAction("Index");

        }

    }
}
