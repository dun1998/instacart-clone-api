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

    public async Task<GroceryItem?> CreateGroceryItemAsync(string name, decimal price, string description,
        int? categoryId = null)
    {
        GroceryItem? groceryItem = new GroceryItem
        {
            Name = name,
            Price = price,
            Description = description,
            CategoryId = categoryId,
        };
        
        //Check constraints
        var itemExists = await _context.GroceryItems.AnyAsync(i => 
            i.Name == groceryItem.Name && i.Price == groceryItem.Price);
        var categoryExists = await _context.GroceryCategories.AnyAsync(i => 
            i.Id == groceryItem.CategoryId);
        
        if (itemExists || !categoryExists)
        {
            return null;
        }
        await  _context.AddAsync(groceryItem);
        await _context.SaveChangesAsync();
        return groceryItem;
    }
    
}