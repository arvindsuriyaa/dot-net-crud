using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository
{
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepo(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }
        public void Update(ShoppingCart ShoppingCart)
        {
            _context.ShoppingCarts.Update(ShoppingCart);
        }
    }
}
