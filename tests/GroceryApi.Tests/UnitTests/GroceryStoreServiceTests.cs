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
}