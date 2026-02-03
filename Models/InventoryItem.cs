using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models;

public class InventoryItem
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = default!;

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public string Supplier { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}