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
    public class CategoryRepo : Repository<Category>, ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
