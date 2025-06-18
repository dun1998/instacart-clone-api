using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GroceryApi.Tests.UnitTests;

public class GroceryCompanyItemServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(0.0000000000000000000000000001)]
    public async Task CreateGroceryCompanyItem_WithValidData_ReturnsGroceryCompanyItem(decimal? price)
    {
        var context = UnitTestUtil.CreatInMemoryDbContext();
        var companyId = 1;
        var groceryItemId = 1;
        ILogger<GroceryCompanyItemService> logger = new Mock<ILogger<GroceryCompanyItemService>>().Object;

        GroceryCompany company = new GroceryCompany()
        {
            Id = companyId,
            Name = "Grocery Company",
        };
        await context.GroceryCompanies.AddAsync(company);

        GroceryItem groceryItem = new GroceryItem()
        {
            Id = groceryItemId,
            Name = "Grocery Item",
            Category = null,
            CategoryId = null,
            Description = "A grocery item",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
        await context.GroceryItems.AddAsync(groceryItem);
        await context.SaveChangesAsync();

        var service = new GroceryCompanyItemService(logger, context);
        var groceryCompanyItem = await service.CreateGroceryCompanyItemAsync();

        Assert.NotNull(groceryCompanyItem);
        Assert.Equal(groceryCompanyItem.CompanyId, companyId);
        Assert.Equal(groceryCompanyItem.GroceryItemId, groceryItemId);
        Assert.Equal(groceryCompanyItem.Price, price);
    }
}