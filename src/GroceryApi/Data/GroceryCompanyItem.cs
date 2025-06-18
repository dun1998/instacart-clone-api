namespace GroceryApi.Data;

public class GroceryCompanyItem
{
    public int Id { get; set; }
    public int GroceryItemId { get; set; }
    public GroceryItem GroceryItem { get; set; } = null!;
    public int CompanyId { get; set; }
    public GroceryCompany Company { get; set; } = null!;
    public double? Price { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime ModifiedDate { get; set; }
}