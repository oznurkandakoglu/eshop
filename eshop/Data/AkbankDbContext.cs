using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data
{
    public class AkbankDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
