
using BookStoreWeb.data.Repository;
using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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

        public IActionResult Details(int productId)
        {
            var cartDb = _db.ShoppingCart.GetFirstOrDefault(u => u.ProductId == productId);
            var count = 1;
            if(cartDb != null)
            {
                count = cartDb.Count;
            }
            ShoppingCart cart = new ShoppingCart()
            {
                Count = count,
                ProductId = productId,
                Product = _db.Products.GetFirstOrDefault(x => x.Id == productId, includeProp: "Category,CoverType"),
            };

            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart cartObj)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            cartObj.ApplicationUserId = claim.Value;

            ShoppingCart cartData = _db.ShoppingCart.GetFirstOrDefault(u => u.ApplicationUserId == cartObj.ApplicationUserId && u.ProductId == cartObj.ProductId);

            if (cartData == null)
            {
                _db.ShoppingCart.Add(cartObj);
            }
            else
            {
                cartData.Count = cartObj.Count;
                _db.ShoppingCart.Update(cartData);
            }
            _db.Save();

            return RedirectToAction("Index");
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