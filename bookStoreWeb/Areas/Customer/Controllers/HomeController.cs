
using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bookStoreWeb.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModel> productList = _db.Products.GetAll(includeProp: "Category,CoverType");

            return View(productList);
        }

        public IActionResult Details(int id)
        {

            ShoppingCart cart = new ShoppingCart()
            {
                Count = 0,
                Product = _db.Products.GetFirstOrDefault(x => x.Id == id, includeProp: "Category,CoverType"),
            };



            return View(cart);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}