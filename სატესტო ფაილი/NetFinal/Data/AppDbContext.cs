using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Product> Suppliers { get; set; }
}