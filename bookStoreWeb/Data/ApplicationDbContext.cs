using bookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace bookStoreWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
