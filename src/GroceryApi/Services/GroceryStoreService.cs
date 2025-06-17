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

    public async Task<GroceryStore?> CreateGroceryStoreAsync(string name, int companyId, string address)
    {
        GroceryStore store = new GroceryStore()
        {
            Name = name,
            CompanyId = companyId,
            Address = address
        };


        await _context.AddAsync(store);
        await _context.SaveChangesAsync();
        return store;
    }
}