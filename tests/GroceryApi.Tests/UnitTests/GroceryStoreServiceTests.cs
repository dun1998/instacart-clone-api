using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GroceryApi.Tests.UnitTests;

public class GroceryStoreServiceTests
{
    [Fact]
    public async Task CreateGroceryStore_Should_Create_GroceryStore()
    {
        await using var context = UnitTestUtil.CreatInMemoryDbContext();
        GroceryCompany company = new GroceryCompany()
        {
            Id = 1,
            Name = "Grocery Company"
        };
        await context.GroceryCompanies.AddAsync(company);
        await context.SaveChangesAsync();

        var storeName = "My Store";
        var companyId = 1;
        var address = "123 456 789";
        var mockLogger = new Mock<ILogger<GroceryStoreService>>();
        GroceryStoreService service = new GroceryStoreService(mockLogger.Object, context);

        GroceryStore? store = await service.CreateGroceryStoreAsync(storeName, companyId, address);

        Assert.NotNull(store);
        Assert.Equal(storeName, store.Name);
        Assert.Equal(companyId, store.CompanyId);
        Assert.Equal(address, store.Address);
    }

    [Fact]
    public async Task CreateGroceryStore_Should_ReturnNull_With_Invalid_CompanyId()
    {
        await using var context = UnitTestUtil.CreatInMemoryDbContext();
        var storeName = "My Store";
        var companyId = 1;
        var address = "123 456 789";
        var mockLogger = new Mock<ILogger<GroceryStoreService>>();

        GroceryStoreService service = new GroceryStoreService(mockLogger.Object, context);

        var result = await service.CreateGroceryStoreAsync(storeName, companyId, address);
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateGroceryStore_Should_ReturnNull_With_Duplicate_GroceryStore()
    {
        await using var context = UnitTestUtil.CreatInMemoryDbContext();
        var storeName = "My Store";
        var companyId = 1;
        var address = "123 456 789";
        GroceryCompany company = new GroceryCompany()
        {
            Id = companyId,
            Name = "Grocery Company"
        };
        await context.GroceryCompanies.AddAsync(company);
        await context.SaveChangesAsync();
        var mockLogger = new Mock<ILogger<GroceryStoreService>>();
        GroceryStoreService service = new GroceryStoreService(mockLogger.Object, context);

        var result = await service.CreateGroceryStoreAsync(storeName, companyId, address);
        var result2 = await service.CreateGroceryStoreAsync(storeName, companyId, address);

        Assert.NotNull(result);
        Assert.Null(result2);
    }
}