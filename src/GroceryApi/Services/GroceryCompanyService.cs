using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

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
        var companyExists = await _context.GroceryCompanies.AnyAsync(c => c.Name == name);
        if (companyExists)
        {
            _logger.LogDebug("Company with that name already exists");
            return null;
        }

        GroceryCompany company = new GroceryCompany()
        {
            Name = name
        };
        await _context.GroceryCompanies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company;
    }
}