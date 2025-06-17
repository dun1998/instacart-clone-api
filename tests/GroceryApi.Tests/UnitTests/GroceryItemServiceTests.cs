using GroceryApi.Data;
using GroceryApi.Services;

namespace GroceryApi.Tests.UnitTests;

public class GroceryItemServiceTests
{
    [Fact]
    public async Task CreateGroceryItem_Should_Create_GroceryItem()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
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
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        decimal price = 12m;
        string description = "Yellow and delicious";

        var item = await service.CreateGroceryItemAsync(itemName, price, description);
        Assert.NotNull(item);
        var item2 = await service.CreateGroceryItemAsync(itemName, price, description);
        Assert.Null(item2);
    }

    [Fact]
    public async Task CreateGroceryItem_Allows_Null_Category()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        decimal price = 12m;
        string description = "Yellow and delicious";
        var item = await service.CreateGroceryItemAsync(itemName, price, description, categoryId: null);
        Assert.NotNull(item);
    }

    [Fact]
    public async Task CreateGroceryItem_Should_ReturnNull_WhenCategoryDoesNotExist()
    {
        using var context = UnitTestUtil.CreatInMemoryDbContext();
        var service = new GroceryItemService(context);
        string itemName = "Cheddar cheese";
        decimal price = 12m;
        string description = "Yellow and delicious";
        int cateogryId = 1;
        var item = await service.CreateGroceryItemAsync(itemName, price, description, cateogryId);
        Assert.Null(item);
    }
}