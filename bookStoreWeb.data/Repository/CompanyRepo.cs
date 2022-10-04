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
    public class CompanyRepo : Repository<CompanyModel>, ICompany
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepo(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(CompanyModel company)
        {
            _context.Company.Update(company);
        }
    }
}
