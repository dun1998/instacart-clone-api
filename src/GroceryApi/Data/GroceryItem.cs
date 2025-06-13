namespace GroceryApi.Data;

public class GroceryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public int? CategoryId { get; set; } = null;
    public GroceryCategory? Category { get; set; } = null;
    

}