using GroceryApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GroceryApi.Tests.UnitTests;

public class GroceryStoreServiceTests
{
    [Fact]
    public async Task CreateGroceryStore_Should_Create_GroceryStore()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var storeName = "My Store";

        var mockLogger = new Mock<ILogger<GroceryStoreService>>();

        GroceryStoreService service = new GroceryStoreService(mockLogger.Object, context);

        await service.CreateGroceryStoreAsync();
    }
}