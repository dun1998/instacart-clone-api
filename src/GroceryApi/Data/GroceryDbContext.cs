using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Data;

public class GroceryDbContext : DbContext
{
    public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
    {
    }

    public DbSet<GroceryItem> GroceryItems { get; set; }
    public DbSet<GroceryCategory> GroceryCategories { get; set; }
    public DbSet<GroceryStore> GroceryStores { get; set; }
    public DbSet<GroceryCompany> GroceryCompanies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GroceryItem>()
            .HasIndex(b => new { b.Name })
            .IsUnique();

        modelBuilder.Entity<GroceryStore>()
            .HasIndex(b => new { b.Name, b.CompanyId })
            .IsUnique();
    }
}