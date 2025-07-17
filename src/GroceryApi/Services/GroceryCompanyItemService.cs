using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Services;

public class GroceryCompanyItemService
{
    private readonly GroceryDbContext _context;
    private readonly ILogger<GroceryCompanyItemService> _logger;

    public GroceryCompanyItemService(ILogger<GroceryCompanyItemService> logger, GroceryDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<GroceryCompanyItem?> CreateGroceryCompanyItemAsync(int companyId, int groceryItemId,
        decimal? price)
    {
        DateTime createdDate = DateTime.Now;
        GroceryCompanyItem groceryCompanyItem = new GroceryCompanyItem()
        {
            CompanyId = companyId,
            GroceryItemId = groceryItemId,
            Price = price,
            CreatedDate = createdDate,
            ModifiedDate = createdDate
        };

        bool itemExists = await _context.GroceryCompanyItems
            .AnyAsync(x => x.CompanyId == companyId && x.GroceryItemId == groceryItemId);
        bool groceryItemExists = await _context.GroceryItems.AnyAsync(g => g.Id == groceryItemId);
        bool groceryCompanyExists = await _context.GroceryCompanies.AnyAsync(g => g.Id == companyId);
        if (itemExists || !groceryItemExists || !groceryCompanyExists || groceryCompanyItem.Price < 0)
        {
            _logger.LogDebug("Failed to create grocery company item");
            return null;
        }

        await _context.GroceryCompanyItems.AddAsync(groceryCompanyItem);
        await _context.SaveChangesAsync();
        return groceryCompanyItem;
    }
}