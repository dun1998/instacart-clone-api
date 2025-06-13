
using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Tests.UnitTests;

public class GroceryItemServiceTests
{
    [Fact]
    public async Task CreateGroceryItem_Should_Create_GroceryItem()
    {
        var options = new DbContextOptionsBuilder<GroceryDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // unique DB per test
            .Options;

        using var context = new GroceryDbContext(options);
        
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        decimal price = 12m;
        string description = "Yellow and delicious";
        
        GroceryItem? groceryItem = await service.CreateGroceryItemAsync(itemName, price, description);
        Assert.NotNull(groceryItem);
        
        Assert.Equal(groceryItem.Name, itemName);
        Assert.Equal(groceryItem.Price, price);
        Assert.Equal(groceryItem.Description, description);

    }

    [Fact]
    public async Task CreateGroceryItem_Should_Not_Allow_Duplicate_GroceryItems()
    {
        var options = new DbContextOptionsBuilder<GroceryDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        using var context = new GroceryDbContext(options);
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        decimal price = 12m;
        string description = "Yellow and delicious";
        
        var item = await service.CreateGroceryItemAsync(itemName, price, description);
        Assert.NotNull(item);
        var item2 = await service.CreateGroceryItemAsync(itemName, price, description);
        Assert.Null(item2);

    }

}