using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

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

        var companyExists = await _context.GroceryCompanies
            .AnyAsync(c => c.Id == companyId);
        var storeExists = await _context.GroceryStores.AnyAsync(g => g.CompanyId == companyId && g.Name == name);
        if (!companyExists | storeExists)
        {
            _logger.LogDebug("Failed to create grocery store");
            return null;
        }

        await _context.AddAsync(store);
        await _context.SaveChangesAsync();
        return store;
    }
}