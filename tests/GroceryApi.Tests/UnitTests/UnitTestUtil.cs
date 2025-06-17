using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Tests.UnitTests;

public static class UnitTestUtil
{
    public static GroceryDbContext CreatInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<GroceryDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unique DB per test
            .Options;

        return new GroceryDbContext(options);
    }
}