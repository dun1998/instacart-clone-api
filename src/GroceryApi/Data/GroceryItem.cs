using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Data;

public class GroceryItem
{
    public int Id { get; set; }

    [MaxLength(255)] public string Name { get; set; } = null!;

    [MaxLength(5000)] public string Description { get; set; } = null!;

    public int? CategoryId { get; set; }
    public GroceryCategory? Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GroceryItem)obj);
    }

    public override int GetHashCode()
    {
        throw new InvalidOperationException();
    }

    private bool Equals(GroceryItem other)
    {
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id
               && string.Equals(Name, other.Name)
               && string.Equals(Description, other.Description)
               && CategoryId == other.CategoryId;
    }
}