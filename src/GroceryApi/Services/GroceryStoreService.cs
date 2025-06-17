using GroceryApi.Data;

namespace GroceryApi.Services;

public class GroceryStoreService
{
    private readonly GroceryDbContext _context;
    private readonly ILogger<GroceryStoreService> _logger;

    public GroceryStoreService(ILogger<GroceryStoreService> logger, GroceryDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public Task<GroceryStore> CreateGroceryStoreAsync()
    {
        throw new NotImplementedException();
    }
}