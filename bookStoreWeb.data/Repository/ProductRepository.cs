using BookStoreWeb.data.Repository.IRepository;
using BookStoreWeb.Data;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository
{
    public class CoverTypeRepository : Repository<CoverTypeModel>, ICoverType
    {
        private readonly ApplicationDbContext _context;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(CoverTypeModel CoverTypeModel)
        {
            _context.CoverType.Update(CoverTypeModel);
        }
    }
}
