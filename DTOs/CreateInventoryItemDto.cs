namespace Inventory.Api.DTOs;

public class CreateInventoryItemDto
{
    public string Name { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Supplier { get; set; } = default!;
}