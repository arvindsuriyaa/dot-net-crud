
using BookStoreWeb.data;
using BookStoreWeb.data.Repository.IRepository;
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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _db;
     

        public CompanyController(IUnitOfWork db)
        {
            _db = db;
        }

        //GET Book
        public IActionResult Index()
        {
            IEnumerable<CompanyModel> companyList = _db.Company.GetAll();

            return View(companyList);
        }


        //Render Create Form
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            CompanyModel company = new();

            if (id == null || id == 0)
            {
                //Create
                return View(company);
            }
            else
            {
                company = _db.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);
            }

        }

        //Post Created/Edited Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CompanyModel obj)
        {
            if (ModelState.IsValid)
            {
               
               
                if (obj.Id == 0)
                {

                    _db.Company.Add(obj);
                }
                else
                {
                    _db.Company.Update(obj);
                }
                _db.Save();
                TempData["Success"] = "Company successfully created";
                return RedirectToAction("Index");
            }
            return Upsert(obj);
        }

        #region API End points

        public IActionResult getAll()
        {
            var companyList = _db.Company.GetAll();
            return Json(new { data = companyList });
        }


        [HttpGet]// httpget for delete because to retreive ID from params..
        public IActionResult Delete(int? id)
        {
            var userDetails = _db.Company.GetFirstOrDefault(item => item.Id == id);
            if (userDetails == null)
            {
                return Json(new { Error = true, message = "Error while deleting" });
            }
            _db.Company.Remove(userDetails);
            _db.Save();
            return Json(new { Error = false, message = "Delete success" });
        }
        #endregion

    }
}
