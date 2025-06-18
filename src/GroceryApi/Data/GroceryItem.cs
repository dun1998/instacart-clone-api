using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Data;

public class GroceryItem
{
    public int Id { get; set; }

    [MaxLength(255)] public string Name { get; set; } = null!;

    [MaxLength(5000)] public string Description { get; set; } = null!;

    public int? CategoryId { get; set; } = null;
    public GroceryCategory? Category { get; set; } = null;
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}