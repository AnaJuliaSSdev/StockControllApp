using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace StockApp2._0.Context;

public class StockAppContext : DbContext
{
    public StockAppContext(DbContextOptions<StockAppContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Batch> Batches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Navigation(p => p.Category)
            .AutoInclude();
    }
}
