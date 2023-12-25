using Microsoft.EntityFrameworkCore;
using ProductManage.Models;

namespace ProductManage.DBOperations;

// The ProductDbContext class represents the database context for managing Product entities.
public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}   