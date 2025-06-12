using GroceryApi.Data;

namespace GroceryApi.Services;

public class GroceryItemService
{
    private readonly GroceryDbContext _context;

    public GroceryItemService(GroceryDbContext context)
    {
        _context = context;
    }

    public async Task<GroceryItem?> CreateGroceryItemAsync(string name, decimal price, string description,
        GroceryCategory? category = null, int? stockQuantity = null)
    {
        return null;
    }
    
}