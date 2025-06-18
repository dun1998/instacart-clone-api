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

    public async Task<GroceryCompanyItem?> CreateGroceryCompanyItemAsync()
    {
        throw new NotImplementedException();
    }
}