using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace GroceryApi.Tests.UnitTests;

public class GroceryCompanyServiceTests
{
    [Fact]
    public async Task CreateGroceryCompany_Should_Create_GroceryCompany()
    {
        var context = UnitTestUtil.CreatInMemoryDbContext();
        var companyName = "My Company";
        var logger = new Mock<ILogger<GroceryCompanyService>>();
        var service = new GroceryCompanyService(logger.Object, context);

        GroceryCompany? company = await service.CreateGroceryCompany(companyName);
        Assert.NotNull(company);
        Assert.Equal(companyName, company.Name);
        Assert.True(
            await context.GroceryCompanies
                .AnyAsync(groceryCompany => groceryCompany.Id == company.Id &&
                                            groceryCompany.Name == company.Name));
    }
}