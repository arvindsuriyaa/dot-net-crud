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
    public class ApplicationUsersRepo : Repository<ApplicationUsers>, IApplicationUsersRepo
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUsersRepo(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }
    }
}
