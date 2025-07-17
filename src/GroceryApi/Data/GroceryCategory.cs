using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Data;

public class GroceryCategory
{
    public int Id { get; set; }

    [MaxLength(250)] public string Name { get; set; } = null!;
}