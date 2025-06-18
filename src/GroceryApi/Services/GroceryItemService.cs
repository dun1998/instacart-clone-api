using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Services;

public class GroceryItemService
{
    private readonly GroceryDbContext _context;

    public GroceryItemService(GroceryDbContext context)
    {
        _context = context;
    }

    public async Task<GroceryItem?> CreateGroceryItemAsync(string name, string description,
        int? categoryId = null)
    {
        var groceryItem = new GroceryItem
        {
            Name = name,
            Description = description,
            CategoryId = categoryId
        };

        //Check constraints
        var itemExists = await _context.GroceryItems.AnyAsync(i =>
            i.Name == groceryItem.Name);
        var categoryExists = await _context.GroceryCategories.AnyAsync(i =>
            i.Id == groceryItem.CategoryId);

        if (itemExists || (!categoryExists && categoryId.HasValue)) return null;
        await _context.AddAsync(groceryItem);
        await _context.SaveChangesAsync();
        return groceryItem;
    }
}