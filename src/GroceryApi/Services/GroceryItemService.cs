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
        GroceryCategory? category = null)
    {
        GroceryItem? groceryItem = new GroceryItem
        {
            Name = name,
            Price = price,
            Description = description,
            Category = category,
        };
        await  _context.AddAsync(groceryItem);
        await _context.SaveChangesAsync();
        return groceryItem;
    }
    
}