using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Data;

public class GroceryCompany
{
    public int Id { get; set; }

    [MaxLength(250)] public required string Name { get; set; }
}