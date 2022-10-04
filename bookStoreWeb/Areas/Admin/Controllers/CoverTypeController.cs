
using BookStoreWeb.data;
using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace bookStoreWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;

        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;
        }

        //GET Book
        public IActionResult Index()
        {
            IEnumerable<CoverTypeModel> categoryList = _db.CoverType.GetAll();

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
        public IActionResult Create(CoverTypeModel obj)
        {

            if (ModelState.IsValid)
            {
                _db.CoverType.Add(obj);
                _db.Save();
                TempData["Success"] = "CoverType successfully created";
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
            var categoryFrmDb = _db.CoverType.GetFirstOrDefault(item => item.Id == id);

            return View(categoryFrmDb);
        }

        //Post Edited Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverTypeModel obj)
        {
            List<CoverTypeModel> userDetails = _db.CoverType.GetRepo().Where(u => u.Name == obj.Name).ToList();
            if (userDetails.Count >= 2)
            {
                ModelState.AddModelError("name", "Name already exist, Choose different Name");
            }


            if (ModelState.IsValid)
            {

                _db.CoverType.Update(obj);
                _db.Save();
                TempData["Success"] = "CoverType successfully edited";
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
            var categoryFrmDb = _db.CoverType.GetFirstOrDefault(item => item.Id == id);

            return View(categoryFrmDb);
        }

        //Delete Edited Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var userDetails = _db.CoverType.GetFirstOrDefault(item => item.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }
            _db.CoverType.Remove(userDetails);
            _db.Save();
            TempData["Success"] = "CoverType successfully deleted";
            return RedirectToAction("Index");

        }

    }
}
