using GroceryApi.Data;

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

        await _context.GroceryCompanyItems.AddAsync(groceryCompanyItem);
        await _context.SaveChangesAsync();
        return groceryCompanyItem;
    }
}