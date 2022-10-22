using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Data;
using BookStoreWeb.Data.Repository;
using BookStoreWeb.Data.Repository.IRepository;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Category = new CategoryRepo(_context);
            CoverType = new CoverTypeRepository(_context);
            Products = new ProductRepository(_context);
            Company = new CompanyRepo(_context);
            ApplicationUsers = new ApplicationUsersRepo(_context);
            ShoppingCart = new ShoppingCartRepo(_context);
            OrderDetail = new OrderDetailRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);
        }

        public ICategory Category { get; private set; }
        public ICoverType CoverType { get; private set; }
        public IProductRepository Products { get; private set; }
        public ICompany Company { get; private set; }
        public IApplicationUsersRepo ApplicationUsers { get; private set; }
        public IShoppingCartRepo ShoppingCart { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
