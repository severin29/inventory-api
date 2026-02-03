namespace Inventory.Api.Models;

public class InventoryReport
{
    public int TotalItems { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalValue { get; set; }
    public List<InventoryItem> LowStockItems { get; set; } = new();
}