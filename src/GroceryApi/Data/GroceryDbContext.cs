using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Data;

public class GroceryDbContext : DbContext
{
    public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
    {
    }
    public DbSet<GroceryItem> GroceryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GroceryItem>()
            .HasIndex(b => new {b.Name, b.Price})
            .IsUnique();
    }
}