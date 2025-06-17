using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Data;

public class GroceryStore
{
    public int Id { get; set; }
    [MaxLength(255)] public required string Name { get; set; }
    [MaxLength(1000)] public string? Address { get; set; }
    public required int CompanyId { get; set; }
    public GroceryCompany? Company { get; set; }
    public List<GroceryItem> GroceryItems { get; set; } = [];
}