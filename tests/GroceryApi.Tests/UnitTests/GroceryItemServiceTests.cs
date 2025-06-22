using GroceryApi.Data;
using GroceryApi.Services;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Tests.UnitTests;

public class GroceryItemServiceTests
{
    [Fact]
    public async Task CreateGroceryItem_Should_Create_GroceryItem()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        string description = "Yellow and delicious";

        GroceryItem? groceryItem = await service.CreateGroceryItemAsync(itemName, description);
        Assert.NotNull(groceryItem);
        Assert.Equal(groceryItem.Name, itemName);
        Assert.Equal(groceryItem.Description, description);
        bool isInContext = await context.GroceryItems.AnyAsync(x =>
            x.Name == itemName && x.Description == description && x.Id == groceryItem.Id);
        Assert.True(isInContext);
    }

    [Fact]
    public async Task CreateGroceryItem_Should_Not_Allow_Duplicate_GroceryItems()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        string description = "Yellow and delicious";

        var item = await service.CreateGroceryItemAsync(itemName, description);
        Assert.NotNull(item);
        var item2 = await service.CreateGroceryItemAsync(itemName, description);
        Assert.Null(item2);
    }

    [Fact]
    public async Task CreateGroceryItem_Allows_Null_Category()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        string description = "Yellow and delicious";
        var item = await service.CreateGroceryItemAsync(itemName, description, categoryId: null);
        Assert.NotNull(item);
        var isInContext = await context.GroceryItems
            .AnyAsync(x => x.Name == itemName && x.Description == description && x.Id == item.Id);
        Assert.True(isInContext);
    }

    [Fact]
    public async Task CreateGroceryItem_Should_ReturnNull_WhenCategoryDoesNotExist()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        string description = "Yellow and delicious";
        int cateogryId = 1;
        var item = await service.CreateGroceryItemAsync(itemName, description, cateogryId);
        Assert.Null(item);
    }

    [Fact]
    public async Task ReadGroceryItem_NonExistingId_ReturnsNull()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);

        int groceryItemId = 1;
        var item = await service.ReadGroceryItemAsync(groceryItemId);
        Assert.Null(item);
    }
}