using Microsoft.EntityFrameworkCore;
using NorthernProducts.Models;

namespace NorthernProducts.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Cartegories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
