
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverTypeModel> CoverType { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers{ get; set; }
        public DbSet<CompanyModel> Company{ get; set; }

    }
}
