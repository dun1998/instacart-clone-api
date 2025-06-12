using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Data;

public class GroceryDbContext : DbContext
{
    public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
    {
        throw new NotImplementedException();
    }
}