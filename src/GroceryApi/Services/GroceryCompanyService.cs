using GroceryApi.Data;

namespace GroceryApi.Services;

public class GroceryCompanyService
{
    private GroceryDbContext _context;
    private ILogger<GroceryCompanyService> _logger;

    public GroceryCompanyService(ILogger<GroceryCompanyService> logger, GroceryDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<GroceryCompany?> CreateGroceryCompany(string name)
    {
        GroceryCompany company = new GroceryCompany()
        {
            Name = name
        };

        await _context.GroceryCompanies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company;
    }
}