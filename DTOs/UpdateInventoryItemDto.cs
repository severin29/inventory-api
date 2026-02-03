namespace Inventory.Api.DTOs;

public class UpdateInventoryItemDto
{
    public string? Name { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public string? Supplier { get; set; }
}