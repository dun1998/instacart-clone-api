using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GroceryApi.Tests.UnitTests;

public class GroceryCompanyItemServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData(1.0)]
    [InlineData(0.0)]
    [InlineData(0.000000000000000000000000001)]
    public async Task CreateGroceryCompanyItem_WithValidData_ReturnsGroceryCompanyItem(double? price)
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
        var groceryCompanyItem = await service.CreateGroceryCompanyItemAsync(companyId, groceryItemId, price);

        Assert.NotNull(groceryCompanyItem);
        Assert.NotNull(groceryCompanyItem.Id);
        Assert.Equal(groceryCompanyItem.CompanyId, companyId);
        Assert.Equal(groceryCompanyItem.GroceryItemId, groceryItemId);
        Assert.Equal(groceryCompanyItem.Price, price);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(1.0, 1.0)]
    [InlineData(0.0, null)]
    [InlineData(null, 0.0)]
    [InlineData(double.MaxValue, 0.0)]
    public async Task CreateGroceryCompanyItem_WithDuplicateData_ReturnsNull(double? price, double? price2)
    {
        var context = UnitTestUtil.CreatInMemoryDbContext();
        ILogger<GroceryCompanyItemService> logger = new Mock<ILogger<GroceryCompanyItemService>>().Object;

        var companyId = 1;
        var groceryItemId = 1;

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
            CategoryId = null,
            Description = "A grocery item",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
        await context.GroceryItems.AddAsync(groceryItem);
        await context.SaveChangesAsync();
        var service = new GroceryCompanyItemService(logger, context);

        GroceryCompanyItem? companyItem = await service.CreateGroceryCompanyItemAsync(companyId, groceryItemId, price);
        Assert.NotNull(companyItem);
        GroceryCompanyItem? companyItemDupe =
            await service.CreateGroceryCompanyItemAsync(companyId, groceryItemId, price2);
        Assert.Null(companyItemDupe);
    }
}